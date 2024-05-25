using Core.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Models.EF
{
    public class FoodContext : DbContext
    {
        public FoodContext (DbContextOptions<FoodContext> options) : base(options) {}
        public DbSet<Article> Articles { get; set; }
        public DbSet<Authorized> Authorizeds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
