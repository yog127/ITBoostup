using ITBoostUp.BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBoostUp.BusinessLayer.IRepository
{
    public interface ICompanyRepository
    {
        public int Create(Company company);
        public int Update(Company company);
        public void Delete(int id);

        public List<Company> List();   
        public Company GetElementById(int id);

    }
}
