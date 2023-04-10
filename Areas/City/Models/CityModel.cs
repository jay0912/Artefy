using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Artefy.Areas.City.Models
{
    public class CityModel
    {
        public int? CityID { get; set; }


        [Required(ErrorMessage = "Please Enter City Name")]
        [DisplayName("City Name")]
        public string? CityName { get; set; }

        [Required(ErrorMessage = "Please Enter City Code")]
        [DataType(DataType.Text)]
        public string? CityCode { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [DisplayName("State")]
        public int StateID { get; set; }


        [Required(ErrorMessage = "Please Select Country")]
        [DisplayName("Country")]
        public int CountryID { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

    }

    public class CityDropDown
    {
        public int? CityID { get; set; }

        public string? CityName { get; set; }
    }

}
