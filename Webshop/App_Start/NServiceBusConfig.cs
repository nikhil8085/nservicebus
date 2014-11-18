using Ninject;
using NServiceBus;
using Samples.NServiceBus.Webshop;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;

[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NServiceBusConfig), "Stop")]
namespace Samples.NServiceBus.Webshop
{
    public class NServiceBusConfig
    {
        private static IStartableBus bus;

        public static IBus CreateServiceBus(IKernel kernel)
        {
            var configuration = new BusConfiguration();
            configuration.EndpointName(ConfigurationManager.AppSettings["NServiceBus.EndpointName"]);
            configuration.UseSerialization<JsonSerializer>();
            configuration.UseTransport<SqlServerTransport>();
            configuration.Conventions()
                .DefiningEventsAs(p => p.Namespace != null && p.Namespace.StartsWith("Samples.NServiceBus.Messages") && p.Namespace.EndsWith("Events"))
                .DefiningCommandsAs(p => p.Namespace != null && p.Namespace.StartsWith("Samples.NServiceBus.Messages") && p.Namespace.EndsWith("Commands"));
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.UseContainer<NinjectBuilder>(p => p.ExistingKernel(kernel));
            configuration.EnableInstallers();

            bus = Bus.Create(configuration);
            return bus.Start();
        }
        
        public static void Stop()
        {
            bus.Dispose();
        }
    }
}