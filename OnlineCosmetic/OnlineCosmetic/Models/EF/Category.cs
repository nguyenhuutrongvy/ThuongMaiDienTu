using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("Category")]
    public class Category : Common
    {
        public Category()
        {
            this.News = new HashSet<News>();
            this.Posts = new HashSet<Post>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống!")]
        [StringLength(150, ErrorMessage = "Tiêu đề không được vượt quá 150 ký tự!")]
        public string Title { get; set; }

        public string Alias { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự!")]
        public string Description { get; set; }

        public int Position { get; set; }

        public string SEOTitle { get; set; }

        public string SEODescription { get; set; }

        public string SEOKeywords { get; set; }

        public ICollection<News> News { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}