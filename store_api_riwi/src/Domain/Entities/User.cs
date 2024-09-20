using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store_api_riwi.src.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
