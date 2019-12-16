using System;
using Microsoft.Extensions.Logging;

namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Trims the source and removes all the white space between the words 
    /// </summary>
    public class RemoveWhiteSpaceDecorator: AbstractSourcePreparationDecorator
    {
        private readonly ILogger<RemoveWhiteSpaceDecorator> _logger;

        /// <inheritdoc />
        public RemoveWhiteSpaceDecorator(AbstractSourcePreparationDecorator successor, ILoggerFactory loggerFactory)
        :base(successor, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<RemoveWhiteSpaceDecorator>();
        }

        /// <summary>
        /// Trims the source and removes all the white space between the words
        /// </summary>
        protected override string Decorate(string source)
        {
            _logger.LogTrace($"Entering {nameof(HandlerEnglishTextToIso)}.{nameof(Decorate)}({nameof(source)}: '{source}')");
            
            var result = source?.Trim() ?? "";

            var parts = result.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            
            result = string.Join(" ", parts);

            if(_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug($"Result is: {result} from source: {source}");

            _logger.LogTrace($"Leaving {nameof(HandlerEnglishTextToIso)}.{nameof(Decorate)}({nameof(source)}: '{source}')");
            return result;            
        }
    }
}