

namespace APICollection.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class PolicyCollection : Policies

    {
        [Key]
        public int PolicyCollectionId { get; set; }

        [ForeignKey("PolicyCollectionFile")]
        public Int64 PolicyFileId { get; set; }
        public PolicyCollectionFile PolicyCollectionFile { get; set; } = null!;


        //Relacion con tabla PolicyInformationService (Tabla dónde se guardan datos de la póliza del lado de Leasing)
        [ForeignKey("PolicyInformationService")]
        public Int64 PolicyInfoId { get; set; }
        public PolicyInformationService PolicyInformationService { get; set; } = null!;


        [ForeignKey("Configuration")]
        public Byte ConfigId { get; set; }
        public TimeLimitConfiguration Configuration { get; set; } = null!;

        public List<PolicyCollectionHistory> PoliciesCollectionHistory { get; set; } = null!;
        public List<PolicyComment> Comments { get; set; } = null!;
    }
}
