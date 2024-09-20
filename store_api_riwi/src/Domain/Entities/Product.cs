using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store_api_riwi.src.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public required double Price { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
