using ITBoostUp.BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBoostUp.BusinessLayer.IRepository
{
    public interface ICountryRepository
    {
        public int Create(Country country);
        public int Update(Country country);
        public void Delete(int id);

        public List<Country> List();
        public Country GetElementById(int id);
    }
}
