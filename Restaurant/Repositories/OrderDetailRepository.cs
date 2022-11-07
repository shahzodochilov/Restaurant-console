using Newtonsoft.Json;
using Restaurant.Constants;
using Restaurant.Interfaces.Repositories;
using Restaurant.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly string dbPath = DbConstants.OrderDetailDbPath;
        public async Task<bool> CreateAsync(OrderDetail obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<OrderDetail>>(json);
                list.Add(obj);
                json = JsonConvert.SerializeObject(list);
                await File.WriteAllTextAsync(dbPath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<OrderDetail>>(json);
                int index = list.TakeWhile(x => x.Id != id).Count();
                list.RemoveAt(index);
                json = JsonConvert.SerializeObject(list);
                await File.WriteAllTextAsync(dbPath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<OrderDetail>> GetAllAsync()
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<OrderDetail>>(json);
                return list;
            }
            catch
            {
                return new List<OrderDetail>();
            }
        }

        public async Task<OrderDetail> GetAsync(int id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<OrderDetail>>(json);
                int index = list.TakeWhile(x => x.Id != id).Count();
                return list.ElementAt(index);
            }
            catch
            {
                return new OrderDetail();
            }
        }

        public async Task<bool> UpdateAsync(int id, OrderDetail obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<OrderDetail>>(json);
                int index = list.TakeWhile(x => x.Id != id).Count();
                list[index] = obj;
                json = JsonConvert.SerializeObject(list);
                await File.WriteAllTextAsync(dbPath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
