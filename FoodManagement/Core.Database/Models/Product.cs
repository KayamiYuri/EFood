using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Database.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; } = "";
        [MaxLength(50)]
        public string? Picture { get; set; }
        [MaxLength(500)]
        public string? Intro { get; set; }
        public string? Content { get; set; }
        public double? Price { get; set; }
        [ForeignKey("CategoryId")]
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
