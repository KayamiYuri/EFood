using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Database.Models
{
    [Table("Details")]
    public class Details
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("OrderId")]
        public Guid? OrderId { get; set; }
        [ForeignKey("ProductId")]
        public Guid? ProductId { get; set; }
        public double? Price { get; set; } = 0;
        public int? Amount { get; set; } = 0;
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
