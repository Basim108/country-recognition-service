using Hrimsoft.CountryRecognitionService.Dictionaries;
using Microsoft.Extensions.Logging;

namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Handler recognises textually named countries written in Russian language
    /// </summary>
    public class HandlerRussianTextToIso: AbstractCountryRecognitionHandler
    {
        private readonly ILogger<HandlerRussianTextToIso> _logger;

        /// <inheritdoc />
        public HandlerRussianTextToIso(AbstractCountryRecognitionHandler successor, ILoggerFactory loggerFactory) : base(successor, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HandlerRussianTextToIso>();
        }

        /// <inheritdoc />
        protected override string HandleIso3166(string source)
        {
            _logger.LogTrace($"Entering {nameof(HandlerRussianTextToIso)}.{nameof(HandleIso3166)}({nameof(source)}: '{source}')");
            var result = "";
            
            if (!string.IsNullOrWhiteSpace(source) && source.Length > 2)
            {
                var lowerSource = source.ToLowerInvariant();
                foreach (var pair in CountryCodes.RussianNameByCode)
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

            _logger.LogTrace($"Leaving {nameof(HandlerRussianTextToIso)}.{nameof(HandleIso3166)}({nameof(source)}: '{source}')");
            return result;
        }
   }
}