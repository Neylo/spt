using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserProcessingService.Api.Extensions
{
    public static class LoggerExtension
    {
        public static IServiceCollection RegisterSerilog(this IServiceCollection services)
        {
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            var logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger = logger;

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddSerilog(logger);
            services.AddSingleton<ILoggerFactory>(loggerFactory);

            return services;
        }
    }
}
