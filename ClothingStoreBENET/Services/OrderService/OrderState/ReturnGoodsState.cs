using FurnitureStoreBE.Data;
using FurnitureStoreBE.DTOs.Request.OrderRequest;
using FurnitureStoreBE.Enums;
using FurnitureStoreBE.Models;
using FurnitureStoreBE.Services.FileUploadService;

namespace ClothingStoreBENET.Services.OrderService.OrderState
{
    public class ReturnGoodsState : IOrderState
    {
        public async Task HandleStatusChange(OrderContext context, OrderStatusRequest request, ApplicationDBContext dbContext, IFileUploadService fileUploadService)
        {
            context.Order.OrderStatus = request.EOrderStatus;

            var orderStatus = new OrderStatus
            {
                Order = context.Order,
                ShipperId = request.ShipperId,
                Status = request.EOrderStatus,
                Note = request.Note,
            };

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
