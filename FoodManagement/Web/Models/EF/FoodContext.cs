using Core.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Models.EF
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Nhom
            modelBuilder.Entity<Group>().HasData(
                new Group()
                {
                    Id = Guid.Parse("fec47abf-51ad-42b9-8538-286bb0ec93f1"),
                    Name = "Admin",
                });
            //Thanh Vien 
            modelBuilder.Entity<Member>().HasData(
                new Member()
                {
                    Id = Guid.Parse("e23e4a7c-72fa-499d-8495-a4ea54377aa8"),
                    Name = "Nguyen Ngoc Phuc",
                    Picture = "/img/users/avatar (1).png",
                    LoginName = "ngoc.phuc",
                    Password = "c4ca4238a0b923820dcc509a6f75849b",
                    Email = "ngoc.phuc@dla.edu.vn",
                    CreatedOn = DateTime.Now,
                    GroupId = Guid.Parse("fec47abf-51ad-42b9-8538-286bb0ec93f1"),
                }
            );
            //The loai
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = Guid.Parse("357ab6ba-b001-4faa-a151-bb3da1489453"),
                    Name = "Root",
                    CreatedBy = Guid.Parse("e23e4a7c-72fa-499d-8495-a4ea54377aa8"),
                    CreatedOn = DateTime.Now,
                },
                 //Category Phan quyen
                 new Category()
                 {
                     Id = Guid.Parse("def472c2-1590-4b8d-afff-b84e42b0bbe2"),
                     Name = "Authorized",
                     CreatedBy = Guid.Parse("e23e4a7c-72fa-499d-8495-a4ea54377aa8"),
                     CreatedOn = DateTime.Now,
                     ParentId = Guid.Parse("357ab6ba-b001-4faa-a151-bb3da1489453"), // root
                 },
                 //Nhom quyen
                 new Category()
                 {
                     Id = Guid.Parse("72f3845c-ae64-4093-87ec-072b66a943d1"),
                     Name = "Nhom Quyen",
                     CreatedBy = Guid.Parse("e23e4a7c-72fa-499d-8495-a4ea54377aa8"),
                     CreatedOn = DateTime.Now,
                     ParentId = Guid.Parse("def472c2-1590-4b8d-afff-b84e42b0bbe2"),// Authorized
                 },
                   //Article
                   new Category()
                   {
                       Id = Guid.Parse("51007f20-0d48-493f-b163-d6f37d3bd562"),
                       Name = "Article",
                       CreatedBy = Guid.Parse("e23e4a7c-72fa-499d-8495-a4ea54377aa8"),
                       CreatedOn = DateTime.Now,
                       ParentId = Guid.Parse("357ab6ba-b001-4faa-a151-bb3da1489453"), // root
                   },
                   //Product
                   new Category()
                   {
                       Id = Guid.Parse("b7fdfff4-bca6-411b-9b3e-1f1498c64f7b"),
                       Name = "Product",
                       CreatedBy = Guid.Parse("e23e4a7c-72fa-499d-8495-a4ea54377aa8"),
                       CreatedOn = DateTime.Now,
                       ParentId = Guid.Parse("357ab6ba-b001-4faa-a151-bb3da1489453"), // root
                   }
                );
            //Vai Tro
            modelBuilder.Entity<Role>().HasData(
                //Xem Nhom
                new Role()
                {
                    Id = Guid.Parse("1ef67211-920b-48b6-a9df-512c6ec85ef1"),
                    Name = "Xem danh sach Nhom",
                    Code = "view-groups",
                    CategoryId = Guid.Parse("72f3845c-ae64-4093-87ec-072b66a943d1"), //Nhom Quyen
                },
                 //Chinh Sua Nhom
                 new Role()
                 {
                     Id = Guid.Parse("69ad0aba-087c-48b0-a7ed-83d7cc9342fb"),
                     Name = "Cap Nhat Nhom",
                     Code = "edit-group",
                     CategoryId = Guid.Parse("72f3845c-ae64-4093-87ec-072b66a943d1"), //Nhom Quyen
                 },
                 //Luu Nhom
                 new Role()
                 {
                     Id = Guid.Parse("614baaa4-3b04-4864-a971-ea62da5e24b0"),
                     Name = "Luu Nhom",
                     Code = "save-group",
                     CategoryId = Guid.Parse("72f3845c-ae64-4093-87ec-072b66a943d1"), //Nhom Quyen
                 },
                 //Xoa Nhom
                 new Role()
                 {
                     Id = Guid.Parse("42d9af50-88e4-46df-9392-e1ea60884c2e"),
                     Name = "Xoa Nhom",
                     Code = "delete-group",
                     CategoryId = Guid.Parse("72f3845c-ae64-4093-87ec-072b66a943d1"), //Nhom Quyen
                 }
                 //=================
                );
            //Phan Quyen
            modelBuilder.Entity<Authorized>().HasData(
                //Quyen xem danh sach nhom
                new Authorized()
                {
                    Id = Guid.NewGuid(),
                    GroupId = Guid.Parse("fec47abf-51ad-42b9-8538-286bb0ec93f1"), //Admin
                    RoleId = Guid.Parse("1ef67211-920b-48b6-a9df-512c6ec85ef1"), // Xem danh sach
                },
                //Cap Nhau danh sach nhom
                new Authorized()
                {
                    Id = Guid.NewGuid(),
                    GroupId = Guid.Parse("fec47abf-51ad-42b9-8538-286bb0ec93f1"), //Admin
                    RoleId = Guid.Parse("69ad0aba-087c-48b0-a7ed-83d7cc9342fb"), // Cap Nhat danh sach
                },
                //Luu danh sach nhom
                new Authorized()
                {
                    Id = Guid.NewGuid(),
                    GroupId = Guid.Parse("fec47abf-51ad-42b9-8538-286bb0ec93f1"), //Admin
                    RoleId = Guid.Parse("614baaa4-3b04-4864-a971-ea62da5e24b0"), // Luu danh sach
                },
                //Xoa danh sach nhom
                new Authorized()
                {
                    Id = Guid.NewGuid(),
                    GroupId = Guid.Parse("fec47abf-51ad-42b9-8538-286bb0ec93f1"), //Admin
                    RoleId = Guid.Parse("42d9af50-88e4-46df-9392-e1ea60884c2e"), // Xoa danh sach
                }
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Authorized> Authorizeds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
