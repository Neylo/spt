
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SPTest.UserReceiverService.Api.Consumers.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.Extensions
{
    public static class MassTransisExtension
    {
        public static IServiceCollection RegisterMassTransist(this IServiceCollection services, IConfiguration config)
        {

            services.AddMassTransit(s => 
            {

                s.AddConsumer<GetUserConsumer>();
                s.AddBus(provider =>
                {
                    var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host(config.GetValue<string>("RabbitMq:Host"), h =>
                            {
                                h.Username(config.GetValue<string>("RabbitMq:Username"));
                                h.Password(config.GetValue<string>("RabbitMq:Password"));
                            });

                        cfg.ExchangeType = ExchangeType.Direct;
                    });
                    return bus;
                });
            });

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            return services;
        }
    }
}
