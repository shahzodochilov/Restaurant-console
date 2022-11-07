using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int TableNumber { get; set; }

        public string ClientName { get; set; }

        public double TotalSum { get; set; }

        public string EmployeeName { get; set; }

        public DateTime Date { get; set; }
    }
}
