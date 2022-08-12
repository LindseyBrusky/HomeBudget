using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeBudget.Data
{
    public class BudgetItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BudgetItemId { get; set; }

        public int BankAccountId { get; set; }

        public string? ItemName { get; set; }

        // B - Balance
        // O - One-time
        // D - Daily
        // W - Weekly
        // M - Monthly
        public string? ItemType { get; set; }

        public int? Nth { get; set; }
        
        public string? DayOfWeek { get; set; }
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        public virtual BankAccount? BankAccount { get; set; }
    }
}
