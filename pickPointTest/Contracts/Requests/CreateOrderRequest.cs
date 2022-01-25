using pickPointTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pickPointTest.Contracts.Requests
{
    public class CreateOrderRequest
    {
        [Required]
        public OrderStatus orderStatus { get; set; }
        [Required]
        public string[] orderList { get; set; }
        [Required]
        public decimal orderPrice { get; set; }
        [Required]
        public string postamatNumber { get; set; }
        [Required]
        [RegularExpression(@"^(\+7)*\d{3}[-\s]*\d{3}[\s-]\d{2}[\s-]\d{2}")]
        public string customerPhoneNumber { get; set; }
        [Required]
        public string customerFio { get; set; }
    }
}
