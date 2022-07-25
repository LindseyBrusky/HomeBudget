using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeBudget.Data
{
    public class AppUser
    {
        [Key]
        [StringLength(450)]
        public string UserId { get; set; }

        [ForeignKey("Family")]
        public int? CurrentFamilyId { get; set; }

        public virtual Family Family { get; set; }
    }
}
