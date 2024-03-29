﻿#nullable enable
using AutSoft.UnitySupplements.EventBus;
using AutSoft.UnitySupplements.Samples.ResourceGeneratorSamples;
using AutSoft.UnitySupplements.Samples.VitaminSamples.BindingSamples;
using AutSoft.UnitySupplements.UiComponents.Timeline;
using AutSoft.UnitySupplements.Vitamins;
using Injecter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Unity3D;
using System;
using System.IO;
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
                var serviceProvider = new ServiceCollection().Configure(logger).BuildServiceProvider(true);

                CompositionRoot.ServiceProvider = serviceProvider;

                Application.quitting += OnQuitting;

                void OnQuitting()
                {
                    serviceProvider.Dispose();

                    Application.quitting -= OnQuitting;

                    Log.CloseAndFlush();
                }
            }
            catch (Exception e)
            {
                logger.Fatal(e, "Host terminated unexpectedly");
                throw;
            }
        }

        public static IServiceCollection Configure(this IServiceCollection serviceCollection, Serilog.ILogger logger)
        {
            var jsons = new[]
            {
                ResourcePaths.TextAssets.LoadAppSettings()
            };

            var config = new ConfigurationBuilder()
                .AddJsonStream(new MemoryStream(jsons[0].bytes))
                .Build();

            return serviceCollection
                .AddLogging(b => b.AddSerilog(logger))
                .ConfigureServices(config);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1163:Unused parameter.", Justification = "Will be used later")]
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfigurationRoot config)
        {
            var assemblies = new[] { typeof(AppInstaller).Assembly };

            services.AddInjecter(o => o.UseCaching = true);

            services.AddEventBus(assemblies);

            services.AddSingleton<ICancellation, Cancellation>();

            services.AddSingleton<ListBindingData>();

            services.AddTimeline();

            return services;
        }
    }
}
