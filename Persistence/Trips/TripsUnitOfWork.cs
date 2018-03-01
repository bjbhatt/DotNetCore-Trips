using System.Threading.Tasks;

namespace Trips.Persistence
{
    public class TripsUnitOfWork : ITripsUnitOfWork
    {
        private readonly TripsDbContext _context;
        public IOrganizationRepository Organization { get; private set; }
        public IAllocationRepository Allocations { get; private set; }
        public IUserRoleRepository UserRoles { get; private set; }
        
        public TripsUnitOfWork(TripsDbContext context)
        {
            _context = context;
            Organization = new OrganizationRepository(_context);
            Allocations = new AllocationRepository(_context);
            UserRoles = new UserRoleRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}