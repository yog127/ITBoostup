
using System.ComponentModel.DataAnnotations;

namespace ITBoostUp.BusinessLayer.Model
{
    public class Company
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
