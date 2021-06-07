using Jaeger;
using Jaeger.Samplers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Util;
using System.Reflection;

namespace ERP_API_Shared.Repository
{
    /// <summary>
    /// Configuração do OpenTracing
    /// </summary>
    public static class DistributedTracing
    {
        /// <summary>
        /// Método de extensão da "IServiceCollection" para configuração do OpenTracing
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureOpenTracing(this IServiceCollection services)
        {
            services.AddSingleton<ITracer>(serviceProvider =>
            {
                string serviceName = Assembly.GetEntryAssembly().GetName().Name;

                ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                ISampler sampler = new ConstSampler(sample: true);

                ITracer tracer = new Tracer.Builder(serviceName)
                    .WithLoggerFactory(loggerFactory)
                    .WithSampler(sampler)
                    .Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });

            services.AddOpenTracing();
        }
    }
}