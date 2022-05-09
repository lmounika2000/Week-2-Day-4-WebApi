using DataAccessLayer21.Models;
using DomainLayer21;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer21
{
    public interface IOrdertbBusiness
    {
        //Amazon table
        public Task<List<Amazontb>> GetAllAmazonCountries();
        public Task<Amazontb> GetAmazonCountryById(int id);
        public Task InsertAmazonCountry(Amazontb amazon);
        public Task UpdateAmazonCountry(Amazontb amazon);
        public Task DeleteAmazonCountryById(int id);

        //Orders table
        public Task<List<Orderstb>> GetAllOrders();
        public Task<Orderstb> GetOrderById(int id);
        public Task InsertOrder(Orderstb order);
        public Task UpdateOrder(Orderstb order);
        public Task DeleteOrderById(int id);

        public Task<List<Orderstb>> GetAllOrdersByCreatedDate(DateTime d);

        public Task<List<string>> GetAllUserNames();
    }
}
