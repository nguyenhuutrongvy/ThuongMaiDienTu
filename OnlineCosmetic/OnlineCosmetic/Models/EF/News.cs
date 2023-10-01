using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("News")]
    public class News : Common
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

        [StringLength(4000, ErrorMessage = "Mô tả không được vượt quá 4000 ký tự!")]
        public string Description { get; set; }

        [MaxLength(int.MaxValue)]
        public string Detail { get; set; }

        [MaxLength(4000, ErrorMessage = "Đường dẫn ảnh không được vượt quá 4000 ký tự!")]
        public string Image { get; set; }

        public string SEOTitle { get; set; }

        public string SEODescription { get; set; }

        public string SEOKeywords { get; set; }

        public virtual Category Category { get; set; }
    }
}