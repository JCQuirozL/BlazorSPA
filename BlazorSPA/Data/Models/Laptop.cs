

namespace BlazorSPA.Models
{
    
    using System.ComponentModel.DataAnnotations;
    public class Laptop : Device
    {
        [Required]
        [MaxLength(100)]
        public string Processor { get; set; }

        [Required]
        [MaxLength(20)]
        public string Ram { get; set; }

        [Required]
        [MaxLength(50)]
        public string HDD { get; set; }

        [Required]
        public int Screen { get; set; }
        public float Discount { get; set; }

        public override decimal GetPrice()
        {
            decimal discount;
            discount = (decimal)(Discount / 100) * Price;

            return (Price - discount);
        }
    }
}
