﻿using AutSoft.UnitySupplements.EventBus;
using AutSoft.UnitySupplements.Timeline;
using AutSoft.UnitySupplements.Vitamins;
using Injecter.Hosting.Unity;
using Injecter.Unity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Unity3D;
using System;
using System.Reflection;
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

                host.Start();
                host.RegisterInjectionsOnSceneLoad();

                Application.quitting += OnQuitting;

                void OnQuitting()
                {
                    host.Dispose();
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

        public static IHostBuilder ConfigureHost(this IHostBuilder builder, Serilog.ILogger logger) =>
            builder
                .UseUnity(_ => { }, false, false, Array.Empty<TextAsset>())
                .ConfigureServices(ConfigureServices)
                .UseDefaultServiceProvider(o =>
                {
                    o.ValidateOnBuild = true;
                    o.ValidateScopes = true;
                })
                .UseSerilog(logger);

        public static void ConfigureServices(HostBuilderContext builder, IServiceCollection services)
        {
            var assemblies = new[] { typeof(AppInstaller).Assembly };

            services.AddSceneInjector(
                injecterOptions => injecterOptions.UseCaching = true,
                sceneInjectorOptions =>
                {
                    sceneInjectorOptions.DontDestroyOnLoad = true;
                    sceneInjectorOptions.InjectionBehavior = SceneInjectorOptions.Behavior.Factory;
                });

            services.AddHostedServices(assemblies);
            services.AddEventBus(assemblies);

            services.AddSingleton<ICancellation, Cancellation>();

            services.AddTimeline();
        }

        private static void AddHostedServices(this IServiceCollection services, params Assembly[] assemblies) =>
            services.Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo<IHostedService>())
                .AsSelfWithInterfaces()
                .WithSingletonLifetime());

        public static void RegisterInjectionsOnSceneLoad(this IHost host) => InjectionHelper.RegisterInjectionsOnSceneLoad(host.Services);
    }
}