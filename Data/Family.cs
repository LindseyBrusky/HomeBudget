using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeBudget.Data
{
    public class Family
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyId { get; set; }

        [StringLength(100)]
        public string? FamilyName { get; set; }

        [StringLength(450)]
        public string? Admin { get; set; }

        public ICollection<FamilyUser> FamilyUsers { get; set; }
    }
}
