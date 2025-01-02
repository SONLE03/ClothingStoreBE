using System.ComponentModel.DataAnnotations;

namespace FurnitureStoreBE.DTOs.Request.ProductRequest
{
    public class SizeRequest
    {
        [Required(ErrorMessage = "Size name is required.")]

        public string SizeName { get; set; }
        [Required(ErrorMessage = "Length is required.")]
        public int Length { get; set; }
        [Required(ErrorMessage = "Width is required.")]
        public int Width { get; set; }
        [Required(ErrorMessage = "Human Height is required.")]
        public int HumanHeight { get; set; }
    }
}

