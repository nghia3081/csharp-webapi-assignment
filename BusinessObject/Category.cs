using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int CategoryId { get; set; }
        [StringLength(50, ErrorMessage = "Category Name can not be blank or over 50 characters", MinimumLength = 1)]
        public string? CategoryName { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
