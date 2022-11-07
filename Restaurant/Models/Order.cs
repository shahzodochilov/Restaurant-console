using System;

namespace Restaurant.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int TableNumber { get; set; }

        public int ClientId { get; set; }

        public double TotalSum { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }
    }
}
