using System.ComponentModel.DataAnnotations;

namespace BlazorSPA.Models
{
    public abstract class Device
    {

        [Key]
        public int Id { get; set; }

        
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(100)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(20)]
        public string Color { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        public decimal Price { get; set; }

        public abstract decimal GetPrice();
    }
}
