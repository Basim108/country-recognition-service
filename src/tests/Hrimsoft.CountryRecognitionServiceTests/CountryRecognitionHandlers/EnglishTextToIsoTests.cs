using Hrimsoft.CountryRecognitionService;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Hrimsoft.CountryRecognitionServiceTests.CountryRecognitionHandlers
{
    public class EnglishTextToIsoTests
    {
        private HandlerEnglishTextToIso _testHandler;
        
        [SetUp]
        public void Setup()
        {
            _testHandler = new HandlerEnglishTextToIso(null, NullLoggerFactory.Instance);
        }

        [Test]
        public void Should_convert_lower_case_source()
        {
            var result = _testHandler.ConvertToIso3166("united states");
            
            Assert.AreEqual("US", result);
        }
        
        [Test]
        public void Should_convert_upper_case_source()
        {
            var result = _testHandler.ConvertToIso3166("UNITED KINGDOM");
            
            Assert.AreEqual("GB", result);
        }
        
        [Test(Description = "as GB could be presented as united kingdom as well as great britain, we should check that both variants is working")]
        public void Should_convert_multi_variant_names()
        {
            // as GB could be presented as united kingdom as well as great britain,
            // we should check that both variants is working 
            var result = _testHandler.ConvertToIso3166("Great Britain");
            
            Assert.AreEqual("GB", result);
        }
    }
}