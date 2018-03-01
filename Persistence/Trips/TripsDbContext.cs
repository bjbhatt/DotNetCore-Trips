using System.Linq;
using Microsoft.EntityFrameworkCore;
using Trips.Models;

namespace Trips.Persistence
{
    public class TripsDbContext : DbContext
    {
        public TripsDbContext(DbContextOptions<TripsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Can> Cans { get; set; }
        public DbSet<CanAllocation> CanAllocations { get; set; }
        public DbSet<CanSubAllocation> CanSubAllocations { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<TravelType> TravelTypes { get; set; }
        public DbSet<Miscellaneous> Miscellaneous { get; set; }

        public DbSet<InvitationalTraveler> InvitationalTravelers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
    }
}