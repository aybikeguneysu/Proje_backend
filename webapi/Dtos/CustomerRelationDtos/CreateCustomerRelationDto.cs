namespace webapi.Dtos.CustomerRelationDtos
{
    public class CreateCustomerRelationDto
    {
        public int CustomerID { get; set; }
        public string RelationName { get; set; }
        public string RelatedPersonName { get; set; }
    }
}
