namespace webapi.Dtos.CustomerJobDtos
{
    public class GetByIdCustomerJobDto
    {
        public int JobID { get; set; }
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }
}
