using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Artefy.Areas.State.Models
{
    public class StateModel
    {
        public int? StateID { get; set; }


        [Required(ErrorMessage = "Please Enter State Name")]
        [DisplayName("State Name")]
        public string? StateName { get; set; }


        [Required(ErrorMessage = "Please Enter State Code")]
        [DataType(DataType.Text)]
        public string? StateCode { get; set; }


        [Required(ErrorMessage = "Please Select Country")]
        [DisplayName("Country")]
        public int CountryID { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

    }

    public class StateDropDown
    {
        public int? StateID { get; set; }

        public string? StateName { get; set; }

    }
}
