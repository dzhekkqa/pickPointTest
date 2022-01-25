using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pickPointTest.Models
{
    public class Order
    {
        [Key]
        public int orderNumber { get; set; }
        public OrderStatus orderStatus { get; set; }
        public string[] orderList { get; set; }
        public decimal price { get; set; }
        public string postamatNumber { get; set; }
        public string customerPhoneNumber { get; set; }
        public string customerFio { get; set; }
    }
}
