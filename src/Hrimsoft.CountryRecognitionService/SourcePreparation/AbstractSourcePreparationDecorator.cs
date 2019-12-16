using Microsoft.Extensions.Logging;

namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Template method for source preparation algorithm.
    /// Prepares a source to the recognition process.
    /// For example, trims it, remove all white space between words.
    /// </summary>
    public abstract class AbstractSourcePreparationDecorator
    {
        private readonly AbstractSourcePreparationDecorator _successor;
        private readonly ILogger<AbstractSourcePreparationDecorator> _logger;

        /// <inheritdoc />
        public AbstractSourcePreparationDecorator(AbstractSourcePreparationDecorator successor, ILoggerFactory loggerFactory)
        {
            _successor = successor;
            _logger = loggerFactory.CreateLogger<AbstractSourcePreparationDecorator>();
        }
        
        /// <summary>
        /// Does the preparation
        /// </summary>
        /// <returns>Returns prepared/modified source</returns>
        protected abstract string Decorate(string source);

        /// <summary>
        /// Prepares a source to the recognition process
        /// </summary>
        public string Prepare(string source)
        {
            _logger.LogTrace($"Entering {nameof(Prepare)}({nameof(source)}: '{source}')");

            var result = Decorate(source);
            
            if (string.IsNullOrWhiteSpace(result))
                result = _successor?.Prepare(source);

            _logger.LogTrace($"Leaving {nameof(Prepare)}({nameof(source)}: '{source}')");
            return result;
        }
    }
}