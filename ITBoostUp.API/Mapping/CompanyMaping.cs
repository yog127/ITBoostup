using ITBoostUp.API.DTOs;
using ITBoostUp.BusinessLayer.Model;

namespace ITBoostUp.API.Mapping
{
    public static class CompanyMaping
    {
        public static void MapCompanyDtoWithCompany(this Company company,UpdateCompanyDto updateCompanyDto)
        {
            company.Name = updateCompanyDto.Name;
            company.Address = updateCompanyDto.Address;
        }
    }
}
