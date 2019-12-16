using Hrimsoft.CountryRecognitionService;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Hrimsoft.CountryRecognitionServiceTests.CountryRecognitionHandlers
{
    public class IsoToIsoTests
    {
        private HandlerIsoToIso _testHandler;
        
        [SetUp]
        public void Setup()
        {
            _testHandler = new HandlerIsoToIso(null, NullLoggerFactory.Instance);
        }

        [Test]
        public void Should_convert_lower_case_source()
        {
            var result = _testHandler.ConvertToIso3166("us");
            
            Assert.AreEqual("US", result);
        }
        
        [Test]
        public void Should_convert_upper_case_source()
        {
            var result = _testHandler.ConvertToIso3166("GB");
            
            Assert.AreEqual("GB", result);
        }
    }
}