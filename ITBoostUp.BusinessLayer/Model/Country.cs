using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBoostUp.BusinessLayer.Model
{
    public class Country : AuditEntity
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryDescription { get; set; }
        public int CreatedBy { get; set; }
    }
}
