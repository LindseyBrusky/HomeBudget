using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeBudget.Data
{
    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankAccountId { get; set; }

        public int FamilyId { get; set; }

        [StringLength(100)]
        public string? BankAccountName { get; set; }

        [StringLength(450)]
        public string? Admin { get; set; }

        public virtual Family Family { get; set; }
    }
}
