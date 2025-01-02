using ClothingStoreBENET.Services.NotificationService;
using FurnitureStoreBE.Data;
using FurnitureStoreBE.DTOs.Request.OrderRequest;
using FurnitureStoreBE.Models;
using FurnitureStoreBE.Services.FileUploadService;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreBENET.Services.OrderService.OrderState
{
    public class OrderContext
    {
        public Order Order { get; private set; }
        private IOrderState _currentState;

        public OrderContext(Order order, IOrderState initialState)
        {
            Order = order;
            _currentState = initialState;
        }

        public void SetState(IOrderState state)
        {
            _currentState = state;
        }

        public Task HandleStatusChange(OrderStatusRequest request, ApplicationDBContext dbContext, IFileUploadService fileUploadService, INotificationService notification)
        {
            return _currentState.HandleStatusChange(this, request, dbContext, fileUploadService, notification);
        }
    }

}
