using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("Subscriber")]
    public class Subscriber
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(150, ErrorMessage = "Email không được vượt quá 150 ký tự!")]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}