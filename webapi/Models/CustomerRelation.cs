using System.ComponentModel.DataAnnotations;
namespace webapi.Models
{
    public class CustomerRelation
    {
        [Key]
        public int RelationID { get; set; }
        public int CustomerID { get; set; }
        public string RelationName { get; set; }
        public string RelatedPersonName { get; set; }

        public Customer Customer { get; set; }
    }
}