using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("Advertisement")]
    public class Advertisement : Common
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống!")]
        [StringLength(250, ErrorMessage = "Tiêu đề không được vượt quá 250 ký tự!")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự!")]
        public string Description { get; set; }

        [StringLength(4000, ErrorMessage = "Đường dẫn ảnh không được vượt quá 4000 ký tự!")]
        public string Image { get; set; }

        public int Type { get; set; }

        [StringLength(500, ErrorMessage = "Liên kết không được vượt quá 500 ký tự!")]
        public string Link { get; set; }

        public string SEOTitle { get; set; }

        public string SEODescription { get; set; }

        public string SEOKeywords { get; set; }
    }
}