using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("Customer")]
    public class Customer
    {
        public Customer()
        {
            this.Orders = new List<Orders>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống!")]
        [StringLength(150, ErrorMessage = "Tên không được vượt quá 150 ký tự!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [StringLength(15, ErrorMessage = "Số điện thoại không hợp lệ!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        [StringLength(500, ErrorMessage = "Địa chỉ không được vượt quá 500 ký tự!")]
        public string Address { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}