using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BudgetItems> BudgetItems { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyUser> FamilyUsers { get; set; }
    }
}