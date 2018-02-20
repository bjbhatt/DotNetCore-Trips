using System.Threading.Tasks;

namespace Trips.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TripsDbContext _context;
        public UnitOfWork(TripsDbContext context)
        {
            _context = context;
            Organization = new OrganizationRepository(_context);
            Allocations = new AllocationRepository(_context);
            UserRoles = new UserRoleRepository(_context);
        }
        public IOrganizationRepository Organization { get; private set; }
        public IAllocationRepository Allocations { get; private set; }
        public IUserRoleRepository UserRoles { get; private set; }
        
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