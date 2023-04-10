using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Artefy.Areas.Country.Models
{
    public class CountryModel
    {
        public int? CountryID { get; set; }


        [Required(ErrorMessage = "Please Enter Country Name")]
        [DisplayName("Country Name")]
        public string? CountryName { get; set; }


        [Required(ErrorMessage = "Please Enter Country Code")]
        [DataType(DataType.Text)]
        public string? CountryCode { get; set; }


        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }



    }

    public class CountryDropDown
    {
        public int? CountryID { get; set; }

        public string? CountryName { get; set; }
    }
}
