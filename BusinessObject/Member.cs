
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Member
    {
        public Member()
        {
            Orders = new HashSet<Order>();
        }
        public int MemberId { get; set; }   
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email can not be blank")]
        [StringLength(20)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [StringLength(30)]
        public string? CompanyName { get; set; }
        [StringLength(15)]
        public string? City { get; set; }
        [StringLength(15)]
        public string? Country { get; set; }
        [StringLength(15)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password can not be blank")]
        public string Password { get; set; } = null!;
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
