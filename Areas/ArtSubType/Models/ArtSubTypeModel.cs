using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Artefy.Areas.ArtSubType.Models
{
    public class ArtSubTypeModel
    {

        public int? ArtSubTypeID { get; set; }


        [Required(ErrorMessage = "Please Enter ArtSubType Name")]
        [DisplayName("ArtSubType Name")]
        public string? ArtSubTypeName { get; set; }


        [Required(ErrorMessage = "Please Select ArtType")]
        [DisplayName("ArtType")]
        public int ArtTypeID { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

    }

    public class ArtSubTypeDropDown
    {
        public int? ArtSubTypeID { get; set; }

        public string? ArtSubTypeName { get; set; }

    }


}
