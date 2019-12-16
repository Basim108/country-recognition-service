using System.Linq;
using Hrimsoft.CountryRecognitionService.Dictionaries;
using Microsoft.Extensions.Logging;

namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Handler recognises ISO formatted country codes
    /// </summary>
    public class HandlerIsoToIso: AbstractCountryRecognitionHandler
    {
        private readonly ILogger<HandlerIsoToIso> _logger;

        /// <inheritdoc />
        public HandlerIsoToIso(AbstractCountryRecognitionHandler successor, ILoggerFactory loggerFactory) : base(successor, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HandlerIsoToIso>();
        }

        /// <inheritdoc />
        protected override string HandleIso3166(string source)
        {
            _logger.LogTrace($"Entering {nameof(HandlerIsoToIso)}.{nameof(HandleIso3166)}({nameof(source)}: '{source}')");
            var result = "";
            
            if (!string.IsNullOrWhiteSpace(source) && source.Length == 2)
            {
                var upperSource = source.ToUpperInvariant();
                result = CountryCodes.Iso3166.FirstOrDefault(code => code == upperSource);
            }
            
            if(_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"Result is: {result} from source: {source}");
            
            _logger.LogTrace($"Leaving {nameof(HandlerIsoToIso)}.{nameof(HandleIso3166)}({nameof(source)}: '{source}')");
            return result;
        }
   }
}