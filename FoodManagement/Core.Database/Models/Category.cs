using Core.Database.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Database.Models
{
    [Table("Category")]
    public class Category : IAuditable
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        public String? Name { get; set; }
        [ForeignKey("ParentId")]
        public Guid? ParentId { get; set; }
        public Category? Parent { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public ICollection<Category> ChildCategories { get; set; } = new HashSet<Category>();
        public ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
