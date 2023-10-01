using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCosmetic.Models.EF
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 0)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual Orders Order { get; set; }
    }
}