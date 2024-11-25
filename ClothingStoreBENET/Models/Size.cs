using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureStoreBE.Models
{
    [Table("Size")]
    public class Size : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string SizeName { get; set; }
        public ICollection<ProductVariant>? ProductVariants { get; set; }
    }
}
