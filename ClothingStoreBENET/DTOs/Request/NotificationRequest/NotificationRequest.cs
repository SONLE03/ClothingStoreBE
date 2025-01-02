using FurnitureStoreBE.Models;
using System.ComponentModel.DataAnnotations;

namespace ClothingStoreBENET.DTOs.Request.NotificationRequest
{
    public class NotificationRequest
    {
        [Required(ErrorMessage = "Content is required.")]

        public string Content { get; set; }
        [Required(ErrorMessage = "Title is required.")]

        public string Title { get; set; }
        [Required(ErrorMessage = "UserId is required.")]

        public string UserId { get; set; }
        [Required(ErrorMessage = "Order is required.")]

        public Guid OrderId { get; set; }
    }
}
