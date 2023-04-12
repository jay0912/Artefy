using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Artefy.Areas.User.Models
{
    public class UserModel
    {
        public int? UserID { get; set; }


        [Required(ErrorMessage = "Please Select RoleType")]
        [DisplayName("RoleType")]
        public int RoleTypeID { get; set; }

        public string? ProfilePic { get; set; }

        [Required(ErrorMessage = "Please Enter User Name")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DisplayName("Password")]
        public string Password { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [DisplayName("Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please Select Country")]
        [DisplayName("Country")]
        public int CountryID { get; set; }


        [Required(ErrorMessage = "Please Select State")]
        [DisplayName("Art State")]
        public int StateID { get; set; }

        public int? CityID { get; set; }

        [Required(ErrorMessage = "Please Enter Phone")]
        [DisplayName("Phone")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please Enter Email")]
        [DisplayName("Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Gender")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public IFormFile? File { get; set; }

    }

    public class UserDropDown
    {
        public int? UserID { get; set; }

        public string? UserName { get; set; }
    }
}
