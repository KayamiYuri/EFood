using Core.Database.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Database.Models
{
    [Table("Aticle")]
    public class Article : IAuditable, IMeta
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
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? KeyWord { get ; set ; }
        public string? Description { get ; set ; }
    }
}
