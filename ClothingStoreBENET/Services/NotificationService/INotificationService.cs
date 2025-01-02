using ClothingStoreBENET.DTOs.Request.NotificationRequest;
using FurnitureStoreBE.Models;

namespace ClothingStoreBENET.Services.NotificationService
{
    public interface INotificationService
    {
        Task<List<Notification>> GetNotificationByUserID(string userId);
        Task<Notification> CreateNotification(NotificationRequest notificationRequest);
    }
}
