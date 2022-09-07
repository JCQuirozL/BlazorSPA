
namespace APICollection.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PolicyCollectionHistory : Policies
    {
        [Key]
        public int PolicyCollectionHistoryId { get; set; }

        public int PolicyCollectionId { get; set; }


    }
}
