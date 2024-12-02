using FurnitureStoreBE.Constants;
using FurnitureStoreBE.Models;
using System.ComponentModel.DataAnnotations;

namespace FurnitureStoreBE.DTOs.Request.ProductRequest
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Unit is required.")]
        public string Unit { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Thumbnails is required.")]
        public IFormFile Thumbnail { get; set; }
        [Required(ErrorMessage = "Brand is required.")]
        public Guid BrandId { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "Product variants are required.")]
        public HashSet<ProductVariantRequest>? ProductVariants { get; set; }
        [MinValue(0.0)]
        public decimal? Discount { get; set; }
    }
    public class ProductVariantRequest
    {
        [Required(ErrorMessage = "Color is required.")]
        public Guid ColorId { get; set; }
        [Required(ErrorMessage = "Color is required.")]
        public Guid SizeId { get; set; }


        public long Quantity { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [MinValue(0.0)]

        public decimal Price { get; set; }
        [Required(ErrorMessage = "Images are required.")]
        public List<IFormFile> Images { get; set; }
    }
}
