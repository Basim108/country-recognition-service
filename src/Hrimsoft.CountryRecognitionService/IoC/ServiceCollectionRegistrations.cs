using System;
using Microsoft.Extensions.DependencyInjection;

namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Registers services into the IServiceCollection container 
    /// </summary>
    public static class ServiceCollectionRegistrations
    {
        /// <summary>
        /// Registers all the necessary services for country recognition implementation
        /// </summary>
        public static IServiceCollection AddCountryRecognitionServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services
                .AddTransient<ISourcePreparationFactory, SourcePreparationFactory>()
                .AddTransient<ICountryRecognitionFactory, CountryRecognitionFactory>()
                .AddTransient<ICountryRecognitionService, CountryRecognitionService>();
            
            return services;
        }
    }
}