using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("ProductImage")]
    public class ProductImage
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Đường dẫn ảnh không được để trống!")]
        [StringLength(500, ErrorMessage = "Đường dẫn ảnh không được vượt quá 500 ký tự!")]
        public string Image { get; set; }

        public bool IsDefault { get; set; } = true;

        public virtual Product Product { get; set; }
    }
}