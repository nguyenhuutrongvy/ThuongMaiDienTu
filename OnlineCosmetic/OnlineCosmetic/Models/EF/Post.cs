using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OnlineCosmetic.Models.EF
{
    [Table("Post")]
    public class Post : Common
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống!")]
        [StringLength(250, ErrorMessage = "Tiêu đề không được vượt quá 250 ký tự!")]
        public string Title { get; set; }

        public string Alias { get; set; }

        [MaxLength(4000, ErrorMessage = "Mô tả không được vượt quá 4000 ký tự!")]
        public string Description { get; set; }

        [MaxLength(int.MaxValue)]
        [AllowHtml]
        public string Detail { get; set; }

        [MaxLength(4000, ErrorMessage = "Đường dẫn ảnh không được vượt quá 4000 ký tự!")]
        public string Image { get; set; }

        public string SEOTitle { get; set; }

        public string SEODescription { get; set; }

        public string SEOKeywords { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual Category Category { get; set; }
    }
}