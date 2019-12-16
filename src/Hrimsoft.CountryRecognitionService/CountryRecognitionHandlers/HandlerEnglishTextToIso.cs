using Hrimsoft.CountryRecognitionService.Dictionaries;
using Microsoft.Extensions.Logging;

namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Handler recognises textually named countries written in English language
    /// </summary>
    public class HandlerEnglishTextToIso: AbstractCountryRecognitionHandler
    {
        private readonly ILogger<HandlerEnglishTextToIso> _logger;

        /// <inheritdoc />
        public HandlerEnglishTextToIso(AbstractCountryRecognitionHandler successor, ILoggerFactory loggerFactory) : base(successor, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HandlerEnglishTextToIso>();
        }

        /// <inheritdoc />
        protected override string HandleIso3166(string source)
        {
            _logger.LogTrace($"Entering {nameof(HandlerEnglishTextToIso)}.{nameof(HandleIso3166)}({nameof(source)}: '{source}')");
            var result = "";
            
            if (!string.IsNullOrWhiteSpace(source) && source.Length > 2)
            {
                var lowerSource = source.ToLowerInvariant();
                foreach (var pair in CountryCodes.EnglishNameByCode)
                {
                    if (pair.Value.Contains(lowerSource))
                    {
                        result = pair.Key;
                        break;
                    }
                }
            }

            if(_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"Result is: {result} from source: {source}");

            _logger.LogTrace($"Leaving {nameof(HandlerEnglishTextToIso)}.{nameof(HandleIso3166)}({nameof(source)}: '{source}')");
            return result;
        }
   }
}