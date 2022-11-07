using Restaurant.Interfaces.Repositories;
using Restaurant.Interfaces.Services;
using Restaurant.Models;
using Restaurant.Repositories;
using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IClientRepository clientRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IProductRepository productRepository;

        public OrderService()
        {
            this.orderRepository = new OrderRepository();
            this.clientRepository = new ClientRepository();
            this.employeeRepository = new EmployeeRepository();
            this.orderDetailRepository = new OrderDetailRepository();
            this.productRepository = new ProductRepository();
        }

        public async Task<bool> CreateAsync(OrderCreationalViewModel orderCreationalViewModel)
        {
            Order order = new Order()
            {
                Id = orderCreationalViewModel.Id,
                TableNumber = orderCreationalViewModel.TableNumber,
                ClientId = orderCreationalViewModel.ClientId,
                EmployeeId = orderCreationalViewModel.EmployeeId,
                Date = orderCreationalViewModel.Date
            };
            int idTemp = (await orderDetailRepository.GetAllAsync()).OrderByDescending(x=> x.Id).FirstOrDefault().Id;
            foreach (var orderDetail in orderCreationalViewModel.OrderDetails)
            {
                orderDetail.Id = ++idTemp;
                orderDetail.OrderId = order.Id;
                await orderDetailRepository.CreateAsync(orderDetail);
            }
            order.TotalSum = orderCreationalViewModel.OrderDetails.Join(await productRepository.GetAllAsync(),
                orderDetail => orderDetail.ProductId,
                product => product.Id,
                (orderDetail, product) => new
                {
                    product.Price
                }).Sum(x => x.Price) * 1.15;
            await orderRepository.CreateAsync(order);
            return true;
        }

        public async Task<IList<OrderViewModel>> GetAllAsync()
        {
            var orders = await orderRepository.GetAllAsync();
            /*Query Syntax*/

            var query = from order in orders
                        join client in await clientRepository.GetAllAsync() on order.ClientId equals client.Id
                        join employee in await employeeRepository.GetAllAsync() on order.EmployeeId equals employee.Id
                        select new OrderViewModel
                        {
                            Id = order.Id,
                            TableNumber = order.TableNumber,
                            ClientName = client.Name,
                            EmployeeName = employee.Name,
                            TotalSum = order.TotalSum,
                            Date = order.Date
                        };
            return query.ToList();




            /*Method Syntax*/

            //IList<OrderViewModel> orderViewModels = orders.Join(await employeeRepository.GetAllAsync(),
            //    order => order.EmployeeId,
            //    employee => employee.Id,
            //    (order, employee) => new
            //    {
            //        order, 
            //        employee                    
            //    })
            //    .Join(await clientRepository.GetAllAsync(),
            //    order => order.order.ClientId,
            //    client => client.Id,
            //    (order, client) => new 
            //    {
            //        order, client
            //    })
            //    .Select(p=> new OrderViewModel 
            //    {
            //        Id = p.order.order.Id,
            //        ClientName = p.client.Name,
            //        Date = p.order.order.Date,
            //        EmployeeName = p.order.employee.Name,
            //        TableNumber = p.order.order.TableNumber,
            //        TotalSum = p.order.order.TotalSum,
            //    }).ToList();
            //return orderViewModels;

        }
    }
}
