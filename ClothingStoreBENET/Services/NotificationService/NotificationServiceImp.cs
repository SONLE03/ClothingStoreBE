using ClothingStoreBENET.DTOs.Request.NotificationRequest;
using FurnitureStoreBE.Data;
using FurnitureStoreBE.Exceptions;
using FurnitureStoreBE.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreBENET.Services.NotificationService
{
    public class NotificationServiceImp : INotificationService
    {
        private readonly ApplicationDBContext _dbContext;
        public NotificationServiceImp(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Notification> CreateNotification(NotificationRequest notificationRequest)
        {
            var notification = new Notification
            {
                Title = notificationRequest.Title,
                Content = notificationRequest.Content,
                UserId = notificationRequest.UserId,
                OrderId = notificationRequest.OrderId,
                CreateDate = DateTime.UtcNow,
            };
            await _dbContext.Notification.AddAsync(notification);
            await _dbContext.SaveChangesAsync();
            return notification;
        }

        public async Task<List<Notification>> GetNotificationByUserID(string userId)
        {
            if (!await _dbContext.Users.AnyAsync())
            {
                throw new BusinessException("User not found");
            }
            var notifications = await _dbContext.Notification
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreateDate)
                .Take(20)                             
                .ToListAsync();                       

            return notifications;
        }
    }
}
