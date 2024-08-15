using System.ComponentModel.DataAnnotations;
namespace webapi.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerType { get; set; }
        public int IDNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public decimal NetIncomeAmount { get; set; }

        public ICollection<CustomerJob> Jobs { get; set; }
        public ICollection<CustomerRelation> Relations { get; set; }
    }
}