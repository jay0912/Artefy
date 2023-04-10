using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Artefy.Areas.RoleType.Models
{
    public class RoleTypeModel
    {
        public int? RoleTypeID { get; set; }


        [Required(ErrorMessage = "Please Enter RoleType Name")]
        [DisplayName("RoleType Name")]
        public string? RoleTypeName { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }



    }

    public class RoleTypeDropDown
    {
        public int? RoleTypeID { get; set; }

        public string? RoleTypeName { get; set; }
    }

}
