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

        public Task<List<FamilyUser>> GetFamiliesAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Task.FromResult(_context.FamilyUsers
                .Where(fu => fu.UserId == userId)
                .ToList());
        }
            
    }
}
