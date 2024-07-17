using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using table.Models;

namespace table.context
{
	public class ApplicationDbContext:IdentityDbContext<ApplicationUser,ApplicationRole,string>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<PostNews> Posts{ get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
