namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Creates a chain of country recognition handlers.
    /// </summary>
    public interface ICountryRecognitionFactory
    {
        /// <summary>
        /// Creates a chain of country recognition handlers.
        /// </summary>
        AbstractCountryRecognitionHandler Create();
    }
}