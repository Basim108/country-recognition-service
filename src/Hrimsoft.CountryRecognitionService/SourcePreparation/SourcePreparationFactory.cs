using Microsoft.Extensions.Logging;

namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Creates decorators that will prepare source to the recognition process.
    /// </summary>
    public class SourcePreparationFactory : ISourcePreparationFactory
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<SourcePreparationFactory> _logger;
        
        public SourcePreparationFactory(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<SourcePreparationFactory>();
        }
        
        /// <summary>
        /// Creates decorators that will prepare source to the recognition process.
        /// </summary>
        public AbstractSourcePreparationDecorator Create()
        {
            var removeWhiteSpaceDecorator = new RemoveWhiteSpaceDecorator(null, _loggerFactory);
            return removeWhiteSpaceDecorator;
        }
    }
}