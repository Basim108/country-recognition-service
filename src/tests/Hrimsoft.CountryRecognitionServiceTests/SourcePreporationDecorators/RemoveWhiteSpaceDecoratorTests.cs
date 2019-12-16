using Hrimsoft.CountryRecognitionService;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Hrimsoft.CountryRecognitionServiceTests.SourcePreporationDecorators
{
    public class RemoveWhiteSpaceDecoratorTests
    {
        private RemoveWhiteSpaceDecorator _testDecorator;
        
        [SetUp]
        public void Setup()
        {
            _testDecorator = new RemoveWhiteSpaceDecorator(null, NullLoggerFactory.Instance);
        }
        
        [Test]
        public void Should_remove_right_white_space_in_source()
        {
            var result = _testDecorator.Prepare("   united states");
            
            Assert.AreEqual("united states", result);
        }
        
        [Test]
        public void Should_remove_left_white_space_in_source()
        {
            var result = _testDecorator.Prepare("united states   ");
            
            Assert.AreEqual("united states", result);
        }
        
        [Test]
        public void Should_remove_the_white_space_between_two_words()
        {
            var result = _testDecorator.Prepare("united      states");
            
            Assert.AreEqual("united states", result);
        }
        
        [Test]
        public void Should_remove_the_white_space_between_four_words()
        {
            var result = _testDecorator.Prepare("first  second    third      fourth");
            
            Assert.AreEqual("first second third fourth", result);
        }
    }
}