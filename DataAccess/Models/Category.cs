using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("Category")]
    internal class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [StringLength(50, ErrorMessage = "Category Name can not be over 50 characters")]
        public string? CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
