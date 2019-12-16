namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Creates decorators that will prepare source to the recognition process.
    /// </summary>
    public interface ISourcePreparationFactory
    {
        /// <summary>
        /// Creates decorators that will prepare source to the recognition process.
        /// </summary>
        AbstractSourcePreparationDecorator Create();
    }
}