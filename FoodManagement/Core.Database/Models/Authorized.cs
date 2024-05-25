using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Database.Models
{
    [Table("Authorized")]
    public class Authorized
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("GroupId")]
        public Guid? GroupId { get; set; }
        public Group? Group { get; set; }
        [ForeignKey("RoleId")]
        public Guid? RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
