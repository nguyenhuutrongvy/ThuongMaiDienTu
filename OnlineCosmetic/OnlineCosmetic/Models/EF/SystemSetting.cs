using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("SystemSetting")]
    public class SystemSetting
    {
        [Key]
        [StringLength(50, ErrorMessage = "Khóa cài đặt không được vượt quá 50 ký tự!")]
        public string SettingKey { get; set; }

        [MaxLength(int.MaxValue)]
        public string SettingValue { get; set; }

        [MaxLength(4000, ErrorMessage = "Mô tả cài đặt không được vượt quá 4000 ký tự!")]
        public string SettingDescription { get; set; }
    }
}