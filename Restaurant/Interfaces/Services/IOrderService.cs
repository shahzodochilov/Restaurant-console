using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IList<OrderViewModel>> GetAllAsync();

        Task<bool> CreateAsync(OrderCreationalViewModel orderCreationalViewModel);
    }
}
