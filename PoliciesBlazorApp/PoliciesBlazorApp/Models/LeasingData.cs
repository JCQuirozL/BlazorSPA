using System.ComponentModel.DataAnnotations;

namespace PoliciesBlazorApp.Models
{
    public class LeasingData
    {
        public DateTime? ValidationDate { get; set; }

        [Required(ErrorMessage = "El número de serie no puede quedar vacío")]
        public String Serial { get; set; }


        [Required(ErrorMessage = "El número de folio no puede quedar vacío")]
        public String PaymentFolio { get; set; }

        [Required(ErrorMessage = "El número de referencia no puede quedar vacío")]
        public String ReferenceId { get; set; }

        [Required(ErrorMessage = "El nombre del banco no puede quedar vacío")]
        public String Bank { get; set; }

        [Required(ErrorMessage = "El número de cuenta no puede quedar vacío")]
        public String AccountNumber { get; set; }

        [Required(ErrorMessage = "La fecha de depósito no puede quedar vacía")]
        public DateTime? DocumentDate { get; set; }

        [Required(ErrorMessage = "El monto depositado no puede quedar vacío")]
        public Decimal? DepositAmount { get; set; }
    }
}
