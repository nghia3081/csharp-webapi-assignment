using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Order
    {
        public int MemberId { get; set; }
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? RequireDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        [Required]
        public decimal Freight { get; set; }
        public virtual Member? Member { get; set; } = null!;
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
