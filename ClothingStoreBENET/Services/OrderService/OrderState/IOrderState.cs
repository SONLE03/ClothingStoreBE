using FurnitureStoreBE.Data;
using FurnitureStoreBE.DTOs.Request.OrderRequest;
using FurnitureStoreBE.Services.FileUploadService;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreBENET.Services.OrderService.OrderState
{
    public interface IOrderState
    {
        Task HandleStatusChange(OrderContext context, OrderStatusRequest request, ApplicationDBContext dbContext, IFileUploadService fileUploadService);
    }
}
