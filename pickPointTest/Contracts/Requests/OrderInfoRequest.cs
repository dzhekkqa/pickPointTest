using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pickPointTest.Contracts.Requests
{
    public class OrderInfoRequest
    {
        [Required]
        public int orderNumber { get; set; }
    }
}
