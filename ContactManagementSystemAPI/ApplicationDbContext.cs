using ContactManagementSystemModel;
using Microsoft.EntityFrameworkCore;

namespace ContactManagementSystemAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}