using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class OrderCreationalViewModel
    {
        public int Id { get; set; }

        public int TableNumber { get; set; }

        public int ClientId { get; set; }

        public double TotalSum { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public IList<OrderDetail> OrderDetails { get; set; }

        public OrderCreationalViewModel()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
