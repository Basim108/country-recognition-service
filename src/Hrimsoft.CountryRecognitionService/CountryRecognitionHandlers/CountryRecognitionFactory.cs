using Microsoft.Extensions.Logging;

namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Creates a chain of country recognition handlers.
    /// </summary>
    public class CountryRecognitionFactory: ICountryRecognitionFactory
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<CountryRecognitionFactory> _logger;
        
        public CountryRecognitionFactory(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<CountryRecognitionFactory>();
        }
        
        /// <summary>
        /// Creates a chain of country recognition handlers.
        /// </summary>
        public AbstractCountryRecognitionHandler Create()
        {
            var russianToIso = new HandlerRussianTextToIso(null, _loggerFactory);
            var englishToIso = new HandlerEnglishTextToIso(russianToIso, _loggerFactory);
            var isoToIso = new HandlerIsoToIso(englishToIso, _loggerFactory);
            
            return isoToIso;
        }
    }
}