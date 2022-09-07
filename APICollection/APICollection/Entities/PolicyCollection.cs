

namespace APICollection.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class PolicyCollection : Policies

    {
        [Key]
        public int PolicyCollectionId { get; set; }

        [ForeignKey("PolicyCollectionFile")]
        public int PolicyFileId { get; set; }
        public PolicyCollectionFile PolicyCollectionFile { get; set; } = null!;


        //Relacion con tabla PolicyInformationService (Tabla dónde se guardan datos de la póliza del lado de leasing)
        [ForeignKey("PolicyInformationService")]
        public int PolicyInfoId { get; set; }
        public PolicyInformationService PolicyInformationService { get; set; } = null!;

        
        public List<PolicyCollectionHistory> PoliciesCollectionHistory { get; set; } = null!;
        public List<PolicyComment> Comments { get; set; } = null!;
    }
}
