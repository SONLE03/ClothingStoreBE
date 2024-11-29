using System.ComponentModel.DataAnnotations;

namespace FurnitureStoreBE.DTOs.Response.ProductResponse
{
    public class SizeResponse
    {
        public Guid Id { get; set; }
        public string? SizeName { get; set; }
    }
}

