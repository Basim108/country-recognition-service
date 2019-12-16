using Hrimsoft.CountryRecognitionService;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Hrimsoft.CountryRecognitionServiceTests.RegistrationTests
{
    public class ServiceCollectionRegistrationsTests
    {
        private ServiceProvider _serviceProvider;
        
        [SetUp]
        public void SetUp()
        {
            _serviceProvider = new ServiceCollection()
                .AddCountryRecognitionServices()
                .AddLogging()
                .BuildServiceProvider(); 
        }

        [Test]
        public void Should_register_country_registration_factory()
        {
            var service = _serviceProvider.GetService<ICountryRecognitionFactory>();
            Assert.NotNull(service);
        }
        
        [Test]
        public void Should_register_source_preparation_factory()
        {
            var service = _serviceProvider.GetService<ISourcePreparationFactory>();
            Assert.NotNull(service);
        }
        
        [Test]
        public void Should_register_country_registration_service()
        {
            var service = _serviceProvider.GetService<ICountryRecognitionService>();
            Assert.NotNull(service);
        }
        
        [Test]
        public void Should_register_everything_that_is_needed_to_recognize_a_country()
        {
            var service = _serviceProvider.GetService<ICountryRecognitionService>();
            Assert.NotNull(service);

            var result = service.ConvertToIso3166("Great Britain");
            Assert.AreEqual("GB", result);
        }
    }
}