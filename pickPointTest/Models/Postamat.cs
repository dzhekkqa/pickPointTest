using System.ComponentModel.DataAnnotations;

namespace pickPointTest.Models
{
    public class Postamat
    {
        [Key]
        public string pNumber { get; set; }
        public string pAddress { get; set; }
        public bool pStatus { get; set; }
    }
}
