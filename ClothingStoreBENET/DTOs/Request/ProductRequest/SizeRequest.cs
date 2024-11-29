using System.ComponentModel.DataAnnotations;

namespace FurnitureStoreBE.DTOs.Request.ProductRequest
{
    public class SizeRequest
    {
        [Required(ErrorMessage = "Size name is required.")]

        public string ColorName { get; set; }
    }
}

