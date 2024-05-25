using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Database.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Name { get; set; }
        public ICollection<Member> Members = new HashSet<Member>();
        public ICollection<Authorized> Authorizeds = new HashSet<Authorized>();
    }
}
