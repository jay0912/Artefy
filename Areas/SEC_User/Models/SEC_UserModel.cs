using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Artefy.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {
        public int? UserID { get; set; }


         [Required]
         [DisplayName("RoleType")]
        public int? RoleTypeID { get; set; }

        public string? ProfilePic { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required]
        [DisplayName("Password")]
        public string? Password { get; set; }

        public DateTime? BirthDate { get; set; }

         [Required]
         [DisplayName("Address")]
        public string? Address { get; set; }


         [Required]
         [DisplayName("Country")]
        public int? CountryID { get; set; }


         [Required]
         [DisplayName("Art State")]
        public int? StateID { get; set; }

        public int? CityID { get; set; }

         [Required]
         [DisplayName("Phone")]
        public string? Phone { get; set; }


         [Required]
         [DisplayName("Email")]
        public string? Email { get; set; }


        [Required]
        [DisplayName("Gender")]
        public string? Gender { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public IFormFile? File { get; set; }

    }
}
