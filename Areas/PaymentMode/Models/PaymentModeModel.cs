using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Artefy.Areas.PaymentMode.Models
{
    public class PaymentModeModel
    {
        public int? PaymentModeID { get; set; }


        [Required(ErrorMessage = "Please Enter PaymentMode Name")]
        [DisplayName("PaymentMode Name")]
        public string? PaymentModeName { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }



    }

    public class PaymentModeDropDown
    {
        public int? PaymentModeID { get; set; }

        public string? PaymentModeName { get; set; }
    }

}
