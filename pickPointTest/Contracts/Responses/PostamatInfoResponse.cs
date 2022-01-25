using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pickPointTest.Contracts.Responses
{
    public class PostamatInfoResponse
    {
        public string postamatNumber { get; set; }
        public string postamatAddress { get; set; }
        public bool postamatStatus { get; set; }
    }
}
