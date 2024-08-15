namespace webapi.Dtos.CustomerRelationDtos
{
    public class UpdateCustomerRelationDto
    {
        public int RelationID { get; set; }
        public int CustomerID { get; set; }
        public string RelationName { get; set; }
        public string RelatedPersonName { get; set; }
    }
}
