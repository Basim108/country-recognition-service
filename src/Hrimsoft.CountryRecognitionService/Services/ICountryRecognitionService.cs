namespace Hrimsoft.CountryRecognitionService
{
    /// <summary>
    /// Recognise a country from user profile data.
    /// There are many different ways how a country is represented in UserGeneralDataSet, so this service will handle all of the cases and convert a country to unified form
    /// </summary>
    public interface ICountryRecognitionService
    {
        /// <summary>
        /// Convert inconsistent country representation into ISO 3166 format
        /// </summary>
        /// <param name="source">An inconsistent country code: could be ru, or Россия, or Russia, or Russian, or +7, etc</param>
        /// <returns>Returns country code in ISO 3166 format</returns>
        string ConvertToIso3166(string source);
    }
}