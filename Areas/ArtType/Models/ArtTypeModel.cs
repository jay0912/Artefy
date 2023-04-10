using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Artefy.Areas.ArtType.Models
{
    public class ArtTypeModel
    {
        public int? ArtTypeID { get; set; }

        [Required(ErrorMessage = "Please Enter ArtType Name")]
        [DisplayName("ArtType Name")]
        public string? ArtTypeName { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public class ArtTypeDropDown
        {
            public int? ArtTypeID { get; set; }

            public string? ArtTypeName { get; set; }
        }
    }
}
