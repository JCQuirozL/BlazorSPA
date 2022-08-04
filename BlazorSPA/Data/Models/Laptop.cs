

namespace BlazorSPA.Models
{
    
    using System.ComponentModel.DataAnnotations;
    public class Laptop : Device
    {
        [Required(ErrorMessage ="{0} es requerid@")]
        [MaxLength(100)]
        public string Processor { get; set; }

        [Required(ErrorMessage = "{0} es requerid@")]
        [MaxLength(20)]
        public string Ram { get; set; }

        [Required(ErrorMessage = "{0} es requerid@")]
        [MaxLength(50)]
        public string HDD { get; set; }

        [Required(ErrorMessage = "{0} es requerid@")]
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
