using System.ComponentModel.DataAnnotations;

namespace FurnitureStoreBE.DTOs.Response.ProductResponse
{
    public class SizeResponse
    {
        public Guid Id { get; set; }
        public string? SizeName { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int HumanHeight { get; set; }
    }
}

