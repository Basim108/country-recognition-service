using Microsoft.Extensions.Logging;

namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Template method for recognition algorithm.
    /// </summary>
    public abstract class AbstractCountryRecognitionHandler
    {
        private readonly AbstractCountryRecognitionHandler _successor;
        private readonly ILogger<AbstractCountryRecognitionHandler> _logger;

        /// <inheritdoc />
        public AbstractCountryRecognitionHandler(AbstractCountryRecognitionHandler successor, ILoggerFactory loggerFactory)
        {
            _successor = successor;
            _logger = loggerFactory.CreateLogger<AbstractCountryRecognitionHandler>();
        }
        
        /// <summary>
        /// Recognition implementation method
        /// </summary>
        /// <param name="source">An inconsistent country code: could be ru, or Россия, or Russia, or Russian, or +7, etc</param>
        /// <returns>Returns country code in ISO 3166 format</returns>
        protected abstract string HandleIso3166(string source);

        /// <inheritdoc />
        public string ConvertToIso3166(string source)
        {
            _logger.LogTrace($"Entering {nameof(ConvertToIso3166)}({nameof(source)}: '{source}')");

            var result = HandleIso3166(source);
            
            if (string.IsNullOrWhiteSpace(result))
                result = _successor?.ConvertToIso3166(source);

            _logger.LogTrace($"Leaving {nameof(ConvertToIso3166)}({nameof(source)}: '{source}')");
            return result;
        }
    }
}