using ClothingStoreBENET.DTOs.Request.NotificationRequest;
using ClothingStoreBENET.Services.NotificationService;
using FurnitureStoreBE.Data;
using FurnitureStoreBE.DTOs.Request.OrderRequest;
using FurnitureStoreBE.Enums;
using FurnitureStoreBE.Models;
using FurnitureStoreBE.Services.FileUploadService;

namespace ClothingStoreBENET.Services.OrderService.OrderState
{
    public class RefundState : IOrderState
    {
        public async Task HandleStatusChange(OrderContext context, OrderStatusRequest request, ApplicationDBContext dbContext, IFileUploadService fileUploadService, INotificationService notification)
        {
            var status = request.EOrderStatus;

            context.Order.OrderStatus = request.EOrderStatus;

            var orderStatus = new OrderStatus
            {
                Order = context.Order,
                ShipperId = request.ShipperId,
                Status = request.EOrderStatus,
                Note = request.Note,
            };
            var notificationRequest = new NotificationRequest
            {
                Title = "Order status update notification",
                Content = $"Order number {context.Order.Id} is updated to status {status}",
                OrderId = context.Order.Id,
                UserId = context.Order.UserId
            };
            await notification.CreateNotification(notificationRequest);
            if (request.Images != null)
            {
                var uploadResult = await fileUploadService.UploadFilesAsync(request.Images, EUploadFileFolder.OrderStatus.ToString());
                orderStatus.Asset = uploadResult.Select(img => new Asset
                {
                    Name = img.OriginalFilename,
                    URL = img.Url.ToString(),
                    CloudinaryId = img.PublicId,
                    FolderName = EUploadFileFolder.OrderStatus.ToString()
                }).ToList();
            }

            dbContext.Orders.Update(context.Order);
            await dbContext.OrderStatus.AddAsync(orderStatus);
        }
    }
}
