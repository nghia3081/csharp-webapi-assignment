using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string? ProductName { get; set; }
        private float _weight;
        private decimal _unitPrice;
        private int? _unitInStock;
        public float Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ValidationException("Weight must be over 0");
                }
                _weight = value;
            }
        }
        public decimal UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                if (value < 0)
                {
                    throw new ValidationException("Unit Price can not be negative");
                }
                _unitPrice = value;
            }
        }
        public int? UnitsInStock
        {
            get
            {
                return _unitInStock;
            }
            set
            {
                if (value.HasValue && value < 0)
                {
                    throw new ValidationException("Units In Stock can not be negative");
                }
                _unitInStock = value;
            }
        }
        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
