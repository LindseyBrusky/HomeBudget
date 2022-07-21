using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeBudget.Data
{
    public class FamilyUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyUserId { get; set; }

        public int FamilyId { get; set; }

        [StringLength(450)]
        public string UserId { get; set; }
    }
}
