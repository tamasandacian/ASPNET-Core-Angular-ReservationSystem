using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("Receipt")]
    public class Receipt
    {
        [Key]
        public int? ReceiptId { get; set; }
        //Id = Reservation Id
        public int Id { get; set; }
        public int FieldId { get; set; }
        public double TotalPrice { get; set; }
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Field Field { get; set; }
    }
}