using FurnitureStoreBE.Data;
using FurnitureStoreBE.DTOs.Request.OrderRequest;
using FurnitureStoreBE.Enums;
using FurnitureStoreBE.Exceptions;
using FurnitureStoreBE.Models;
using FurnitureStoreBE.Services.FileUploadService;

namespace ClothingStoreBENET.Services.OrderService.OrderState
{
    public class CanceledState : IOrderState
    {
        public async Task HandleStatusChange(OrderContext context, OrderStatusRequest request, ApplicationDBContext dbContext, IFileUploadService fileUploadService)
        {
            var status = request.EOrderStatus;
            context.Order.OrderStatus = status;
            if(status != EOrderStatus.Pending && status != EOrderStatus.Paid)
            {
                throw new BusinessException("Order can not cancel");
            }
            var orderStatus = new OrderStatus
            {
                Order = context.Order,
                ShipperId = request.ShipperId,
                Status = status,
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
