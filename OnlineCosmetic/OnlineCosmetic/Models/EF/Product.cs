using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("Product")]
    public class Product : Common
    {
        public Product()
        {
            this.OrderDetails = new List<OrderDetail>();
            this.ProductImages = new List<ProductImage>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }

        [StringLength(500, ErrorMessage = "Mã sản phẩm không được vượt quá 500 ký tự!")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống!")]
        [StringLength(250, ErrorMessage = "Tiêu đề không được vượt quá 250 ký tự!")]
        public string Title { get; set; }

        public string Alias { get; set; }

        [MaxLength(4000, ErrorMessage = "Mô tả không được vượt quá 4000 ký tự!")]
        public string Description { get; set; }

        [MaxLength(int.MaxValue)]
        public string Detail { get; set; }

        [MaxLength(4000, ErrorMessage = "Đường dẫn ảnh không được vượt quá 4000 ký tự!")]
        public string Image { get; set; }

        public decimal CostPrice { get; set; }

        public decimal Price { get; set; }

        public decimal PromotionalPrice { get; set; }

        public int Quantity { get; set; }

        public bool IsHomePage { get; set; } = true;

        public bool IsSale { get; set; } = true;

        public bool IsFeature { get; set; } = true;

        public bool IsHot { get; set; } = true;

        public string SEOTitle { get; set; }

        public string SEODescription { get; set; }

        public string SEOKeywords { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
    }
}