using System.ComponentModel.DataAnnotations;

namespace BlazorSPA.Models
{
    public abstract class Device
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(20)]
        public string Color { get; set; }

        [Required]
        public decimal Price { get; set; }

        public abstract decimal GetPrice();
    }
}
