using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pickPointTest.Contracts.Requests
{
    public class UpdateOrderRequest
    {
        [Required]
        public int orderNumber { get; set; }
        public string[] orderList { get; set; }
        public decimal? price { get; set; }
        public string customerPhoneNumber { get; set; }
        public string customerFio { get; set; }
    }
}
