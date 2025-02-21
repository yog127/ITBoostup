using ITBoostUp.API.Response;
using ITBoostUp.BusinessLayer.Model;

namespace ITBoostUp.API.Mapping
{
    public static class CountryMaping
    {
        public static void MapCountryDropDown(this CountryResponse countryResponse, Country country)
        {
            countryResponse.CountryId = country.CountryId;
            countryResponse.CountryName = country.CountryName;
        }
    }
}
