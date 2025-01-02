using ClothingStoreBENET.DTOs.Request.NotificationRequest;
using ClothingStoreBENET.Services.NotificationService;
using FurnitureStoreBE.Common.Pagination;
using FurnitureStoreBE.Constants;
using FurnitureStoreBE.Services.ImportService;
using FurnitureStoreBE.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClothingStoreBENET.Controllers.NotificationController
{
    [ApiController]
    [Route(Routes.NOTIFICATION)]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notifyService;
        public NotificationController(INotificationService notifyService)
        {
            _notifyService = notifyService;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetNotification(string userId)
        {
            return new SuccessfulResponse<object>(await _notifyService.GetNotificationByUserID(userId), (int)HttpStatusCode.OK, "Get notification successfully").GetResponse();
        }
        [HttpPost()]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationRequest notificationRequest)
        {
            return new SuccessfulResponse<object>(await _notifyService.CreateNotification(notificationRequest), (int)HttpStatusCode.Created, "Create notification successfully").GetResponse();
        }
    }
}
