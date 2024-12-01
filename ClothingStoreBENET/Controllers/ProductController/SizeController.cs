using FurnitureStoreBE.Common.Pagination;
using FurnitureStoreBE.Constants;
using FurnitureStoreBE.DTOs.Request.ProductRequest;
using FurnitureStoreBE.Services.ProductService.SizeService;
using FurnitureStoreBE.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FurnitureStoreBE.Controllers.ProductController
{
    [ApiController]
    [Route(Routes.SIZE)]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetSizes([FromQuery] PageInfo pageInfo)
        {
            return new SuccessfulResponse<object>(await _sizeService.GetAllSizes(pageInfo), (int)HttpStatusCode.OK, "Get size successfully").GetResponse();
        }
        [HttpPost()]
        public async Task<IActionResult> Createsize([FromForm] SizeRequest sizeRequest)
        {
            return new SuccessfulResponse<object>(await _sizeService.CreateSize(sizeRequest), (int)HttpStatusCode.Created, "Size created successfully").GetResponse();
        }
        [HttpPut("{sizeId}")]
        public async Task<IActionResult> Updatesize(Guid sizeId, [FromForm] SizeRequest sizeRequest)
        {
            return new SuccessfulResponse<object>(await _sizeService.UpdateSize(sizeId, sizeRequest), (int)HttpStatusCode.OK, "Size modified successfully").GetResponse();
        }
        [HttpDelete("{sizeId}")]
        public async Task<IActionResult> DeleteSize(Guid sizeId)
        {
            await _sizeService.DeleteSize(sizeId);
            return new SuccessfulResponse<object>(null, (int)HttpStatusCode.OK, "Size deleted successfully").GetResponse();

        }
    }
}
