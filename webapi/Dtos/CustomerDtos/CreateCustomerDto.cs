﻿namespace webapi.Dtos.CustomerDtos
{
    public class CreateCustomerDto
    {
        public string CustomerType { get; set; }
        public int IDNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public decimal NetIncomeAmount { get; set; }
    }
}
