using FurnitureStoreBE.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureStoreBE.Models
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public Guid OrderId { get; set; }
        public Order Order  { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
