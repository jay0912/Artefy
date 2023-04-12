using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Artefy.Areas.ArtWork.Models
{
    public class ArtWorkModel
    {
         public int? ArtWorkID { get; set; }
         
         
         [Required(ErrorMessage = "Please Select Art Image")]
         [DisplayName("Art Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Please Enter Art Title")]
        [DisplayName("Art Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Art NO")]
        [DisplayName("Art NO")]
        public string? ArtNo { get; set; }

        [Required(ErrorMessage = "Please Select User")]
        [DisplayName("User")]
        public int UserID { get; set; }


        [Required(ErrorMessage = "Please Enter Art Height")]
        [DisplayName("Art Height")]
        public decimal Height { get; set; }


        [Required(ErrorMessage = "Please Enter Art Width")]
        [DisplayName("Art Width")]
        public decimal Width { get; set; }

         [Required(ErrorMessage = "Please Select Art Type")]
         [DisplayName("Art Type")]
         public int ArtTypeID { get; set; }

        public int? ArtSubTypeID { get; set; }

        [Required(ErrorMessage = "Enter Price")]
        [DisplayName("Price")]
        public string Price { get; set; }

        public string? Description { get; set; }
         
         public DateTime CreationDate { get; set; }
         
         public DateTime ModificationDate { get; set; }

        public IFormFile? File { get; set; }

    }

    public class ArtWorkDropDown
    {
        public int? ArtWorkID { get; set; }

        public string? ArtWorkName { get; set; }
    }
    
}
