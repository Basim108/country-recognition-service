using Hrimsoft.CountryRecognitionService;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Hrimsoft.CountryRecognitionServiceTests.CountryRecognitionHandlers
{
    public class RussianTextToIsoTests
    {
        private HandlerRussianTextToIso _testHandler;
        
        [SetUp]
        public void Setup()
        {
            _testHandler = new HandlerRussianTextToIso(null, NullLoggerFactory.Instance);
        }

        [Test]
        public void Should_convert_lower_case_source()
        {
            var result = _testHandler.ConvertToIso3166("сша");
            
            Assert.AreEqual("US", result);
        }
        
        [Test]
        public void Should_convert_upper_case_source()
        {
            var result = _testHandler.ConvertToIso3166("США");
            
            Assert.AreEqual("US", result);
        }
        
        [Test(Description = "as US could be presented as США as well as Соединенные Штаты Америки, we should check that both variants is working")]
        public void Should_convert_multi_variant_names()
        {
            // as US could be presented as США as well as Соединенные Штаты Америки,
            // we should check that both variants is working 
            var result = _testHandler.ConvertToIso3166("Соединенные Штаты Америки");
            
            Assert.AreEqual("US", result);
        }
    }
}