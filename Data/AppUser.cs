using System.ComponentModel.DataAnnotations;

namespace HomeBudget.Data
{
    public class AppUser
    {
        [Key]
        [StringLength(450)]
        public string UserId { get; set; }
        public int? CurrentFamilyId { get; set; }
    }
}
