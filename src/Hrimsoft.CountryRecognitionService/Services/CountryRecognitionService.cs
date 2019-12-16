using System;
using Microsoft.Extensions.Logging;

namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Prepares source for recognition then initiate the recognition process
    /// </summary>
    public class CountryRecognitionService: ICountryRecognitionService
    {
        private readonly ILogger<CountryRecognitionService> _logger;

        public CountryRecognitionService(
            ICountryRecognitionFactory recognitionHandlerFactory,
            ISourcePreparationFactory sourcePreparationFactory,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CountryRecognitionService>();
            
            RootRecognitionHandler = new Lazy<AbstractCountryRecognitionHandler>(recognitionHandlerFactory.Create);
            SourcePreparationDecorator = new Lazy<AbstractSourcePreparationDecorator>(sourcePreparationFactory.Create);
        }

        /// <summary>
        /// A root of chain of country recognition handlers
        /// </summary>
        public Lazy<AbstractCountryRecognitionHandler> RootRecognitionHandler { get; }
        
        /// <summary>
        ///  Decorators that will prepare source to the recognition process.
        /// </summary>
        public Lazy<AbstractSourcePreparationDecorator> SourcePreparationDecorator { get; }

        /// <inheritdoc />
        public string ConvertToIso3166(string source)
        {
            _logger.LogTrace($"Entering {nameof(ConvertToIso3166)}");
            
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException(nameof(source));
            
            var preparedSource = SourcePreparationDecorator.Value.Prepare(source);
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"Finally prepared value is '{preparedSource}'.");
                _logger.LogDebug($"Finally prepared value is '{preparedSource}'.");
            }

            var result = RootRecognitionHandler.Value.ConvertToIso3166(preparedSource);
            
            _logger.LogTrace($"Leaving {nameof(ConvertToIso3166)}");
            return result;
        }
    }
}