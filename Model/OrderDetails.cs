using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EjemploClase.Model
{
    [Table("Order Details")]
    public class OrderDetails
    {
        [Key]

        public int OrderID { get; set; }
        public int ProductID { get; set; }
    }
}
