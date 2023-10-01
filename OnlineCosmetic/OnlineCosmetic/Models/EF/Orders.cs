using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("Orders")]
    public class Orders : Common
    {
        public Orders()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã không được để trống!")]
        [StringLength(50, ErrorMessage = "Mã không được vượt quá 50 ký tự!")]
        public string Code { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [StringLength(500, ErrorMessage = "Địa chỉ giao hàng không được vượt quá 500 ký tự!")]
        public string DeliveryAddress { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Customer Customer { get; set; }
    }
}