using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("ProductCategory")]
    public class ProductCategory : Common
    {
        public ProductCategory()
        {
            this.Products = new List<Product>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống!")]
        [StringLength(150, ErrorMessage = "Tiêu đề không được vượt quá 150 ký tự!")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự!")]
        public string Description { get; set; }

        [StringLength(500, ErrorMessage = "Icon không được vượt quá 500 ký tự!")]
        public string Icon { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}