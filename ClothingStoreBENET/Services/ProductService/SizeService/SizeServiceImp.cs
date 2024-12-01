using AutoMapper;
using AutoMapper.QueryableExtensions;
using FurnitureStoreBE.Common;
using FurnitureStoreBE.Common.Pagination;
using FurnitureStoreBE.Data;
using FurnitureStoreBE.DTOs.Request.ProductRequest;
using FurnitureStoreBE.DTOs.Response.ProductResponse;
using FurnitureStoreBE.Enums;
using FurnitureStoreBE.Exceptions;
using FurnitureStoreBE.Models;
using FurnitureStoreBE.Services.FileUploadService;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStoreBE.Services.ProductService.SizeService
{
    public class SizeServiceImp : ISizeService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IFileUploadService _fileUploadService;
        private readonly IMapper _mapper;
        public SizeServiceImp(ApplicationDBContext dbContext, IFileUploadService fileUploadService, IMapper mapper)
        {
            _dbContext = dbContext;
            _fileUploadService = fileUploadService;
            _mapper = mapper;
        }
        public async Task<PaginatedList<SizeResponse>> GetAllSizes(PageInfo pageInfo)
        {
            var sizeQuery = _dbContext.Sizes
                .Where(b => !b.IsDeleted)
                .OrderByDescending(b => b.CreatedDate)
                .ProjectTo<SizeResponse>(_mapper.ConfigurationProvider);
            var count = await _dbContext.Colors.CountAsync();
            return await Task.FromResult(PaginatedList<SizeResponse>.ToPagedList(sizeQuery, pageInfo.PageNumber, pageInfo.PageSize));
        }
        public async Task<SizeResponse> CreateSize(SizeRequest sizeRequest)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var size = new Size { SizeName = sizeRequest.SizeName};
                size.setCommonCreate(UserSession.GetUserId());
                await _dbContext.Sizes.AddAsync(size);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return _mapper.Map<SizeResponse>(size);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<SizeResponse> UpdateSize(Guid id, SizeRequest sizeRequest)
        {
            var size = await _dbContext.Sizes.FirstAsync(b => b.Id == id);
            if (size == null) throw new ObjectNotFoundException("Size not found");
            size.SizeName = sizeRequest.SizeName;
            size.setCommonUpdate(UserSession.GetUserId());
            _dbContext.Sizes.Update(size);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<SizeResponse>(size);
        }
        public async Task DeleteSize(Guid id)
        {
            try
            {
                if (!await _dbContext.Sizes.AnyAsync(b => b.Id == id)) throw new ObjectNotFoundException("Size not found");
                var sql = "DELETE FROM \"Size\" WHERE \"Id\" = @p0";
                int affectedRows = await _dbContext.Database.ExecuteSqlRawAsync(sql, id);
                if (affectedRows == 0)
                {
                    sql = "UPDATE \"Size\" SET \"IsDeleted\" = @p0 WHERE \"Id\"  = @p1";
                    await _dbContext.Database.ExecuteSqlRawAsync(sql, true, id);
                }
            }
            catch
            {
                throw new BusinessException("Size removal failed");
            }
        }

    }
}
