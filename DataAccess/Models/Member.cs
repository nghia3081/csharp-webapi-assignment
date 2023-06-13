using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("Member")]
    internal class Member
    {
        public Member()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Column(TypeName = "nvarchar(30)")]
        [StringLength(30)]
        public string? CompanyName { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        [StringLength(15)]
        public string? City { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        [StringLength(15)]
        public string? Country { get; set; }
        [Column(TypeName = "varchar(15)")]
        [StringLength(15)]
        public string Password { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }

    }
}
