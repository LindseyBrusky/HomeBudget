using System.Security.Claims;

namespace HomeBudget.Data
{
    public class FamilyService
    {
        private readonly string _connectionString;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FamilyService(IConfiguration configuration, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<List<Family>> GetFamiliesAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<int> families = _context.FamilyUsers
                .Where(fu => fu.UserId == userId)
                .Select(fu => fu.FamilyId)
                .ToList();

            return Task.FromResult(_context.Families
                .Where(f => families.Contains(f.FamilyId))
                .ToList());
        }

        public Task<List<Family>> CreateFamilyAsync(string familyName)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Family family = new Family { Admin = userId, FamilyName = familyName };
            _context.Add(family);
            _context.SaveChanges();

            FamilyUser familyUser = new FamilyUser { FamilyId = family.FamilyId, UserId = userId };
            _context.Add(familyUser);
            _context.SaveChanges();

            List<int> families = _context.FamilyUsers
                .Where(fu => fu.UserId == userId)
                .Select(fu => fu.FamilyId)
                .ToList();

            return Task.FromResult(_context.Families
                .Where(f => families.Contains(f.FamilyId))
                .ToList());
        }
            
    }
}
