using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("Contact")]
    public class Contact : Common
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống!")]
        [StringLength(150, ErrorMessage = "Tên không được vượt quá 150 ký tự!")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Email không được vượt quá 150 ký tự!")]
        public string Email { get; set; }

        [StringLength(150, ErrorMessage = "Liên kết Website không được vượt quá 150 ký tự!")]
        public string Website { get; set; }

        [StringLength(4000, ErrorMessage = "Tin nhắn không được vượt quá 4000 ký tự!")]
        public string Message { get; set; }

        public bool IsRead { get; set; } = false;
    }
}