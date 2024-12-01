using FurnitureStoreBE.Common.Pagination;
using FurnitureStoreBE.Common;
using FurnitureStoreBE.DTOs.Request.ProductRequest;
using FurnitureStoreBE.DTOs.Response.ProductResponse;

namespace FurnitureStoreBE.Services.ProductService.SizeService
{
    public interface ISizeService
    {
        Task<PaginatedList<SizeResponse>> GetAllSizes(PageInfo pageInfo);
        Task<SizeResponse> CreateSize(SizeRequest colorRequest);
        Task<SizeResponse> UpdateSize(Guid id, SizeRequest colorRequest);
        Task DeleteSize(Guid id);
    }
}
