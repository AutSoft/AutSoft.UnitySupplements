#nullable enable
using AutSoft.UnitySupplements.EventBus;
using AutSoft.UnitySupplements.ResourceGenerator.Sample;
using AutSoft.UnitySupplements.Timeline;
using AutSoft.UnitySupplements.Vitamins;
using Injecter;
using Injecter.Hosting.Unity;
using Injecter.Unity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Unity3D;
using System;
using UnityEngine;

namespace AutSoft.UnitySupplements.Samples
{
    public static class AppInstaller
    {
        public static bool Run { get; set; } = true;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        public static void Install()
        {
            if (!Run) return;

            var logger = new LoggerConfiguration()
                .WriteTo.Unity3D()
                .CreateLogger();

            try
            {
                var host = new HostBuilder()
                    .ConfigureHost(logger)
                    .Build();

                CompositionRoot.ServiceProvider = host.Services;

                host.Start();

                Application.quitting += OnQuitting;

                void OnQuitting()
                {
                    Log.CloseAndFlush();

                    host = null!;

                    Application.quitting -= OnQuitting;
                }
            }
            catch (Exception e)
            {
                logger.Fatal(e, "Host terminated unexpectedly");
                throw;
            }
        }

        public static IHostBuilder ConfigureHost(this IHostBuilder builder, Serilog.ILogger logger)
        {
            var jsons = new[]
            {
                ResourcePaths.TextAssets.LoadAppSettings()
            };

            return builder
                .UseUnity(_ => { }, false, false, jsons)
                .ConfigureServices(ConfigureServices)
                .UseDefaultServiceProvider(o =>
                {
                    o.ValidateOnBuild = true;
                    o.ValidateScopes = true;
                })
                .UseSerilog(logger);
        }

        public static void ConfigureServices(HostBuilderContext builder, IServiceCollection services)
        {
            var assemblies = new[] { typeof(AppInstaller).Assembly };

            services.AddSceneInjector(
                injecterOptions => injecterOptions.UseCaching = true,
                sceneInjectorOptions =>
                {
                    sceneInjectorOptions.DontDestroyOnLoad = true;
                    sceneInjectorOptions.InjectionBehavior = SceneInjectorOptions.Behavior.CompositionRoot;
                });

            services.AddEventBus(assemblies);

            services.AddSingleton<ICancellation, Cancellation>();

            services.AddTimeline();
        }
    }
}
