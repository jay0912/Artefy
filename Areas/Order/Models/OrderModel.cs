using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Artefy.Areas.Order.Models
{
    public class OrderModel
    {
        public int? OrderID { get; set; }

        [Required(ErrorMessage = "Please Enter Order No")]
        [DisplayName("Order NO")]
        public string? OrderNO { get; set; }

        [Required(ErrorMessage = "Please Enter Order Date")]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Please Select User")]
        [DisplayName("User")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please Enter Total Amount")]
        [DisplayName("Total Amount")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Please Select Payment Mode")]
        [DisplayName("PaymnetMode")]
        public int PaymentModeID { get; set; }

        public string? ReferenceNO { get; set; }

        public DateTime? ReferenceDate { get; set; }

        public string? ReferenceBank { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

    }

    public class OrderDetailModel
    {
        public int? OrderDetailID { get; set; }


        [Required(ErrorMessage = "Please Select Order No")]
        [DisplayName("Order No")]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Please Select Art")]
        [DisplayName("Art")]
        public int ArtWorkID { get; set; }


        [Required(ErrorMessage = "Please Enter Amount")]
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        [Required(ErrorMessage = "Please Select User")]
        [DisplayName("User")]
        public int UserID { get; set; }
    }

}
