
using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Shop.Web.Data
{

    public class DataContext : IdentityDbContext<User>

    {
        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }

}
