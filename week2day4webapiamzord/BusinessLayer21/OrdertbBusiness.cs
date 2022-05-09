using DataAccessLAyer21;
using DomainLayer21;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer21
{
    public class OrdertbBusiness : IOrdertbBusiness
    {
        
        private readonly IOrdertbData _ordertbdata;

        
        public OrdertbBusiness(IOrdertbData ordertbdata)
        {
            _ordertbdata = ordertbdata;
        }
        
        //Amazon 
        public async Task DeleteAmazonCountryById(int id)
        {
            await _ordertbdata.DeleteAmazonCountryById(id);
        }

        public async Task<List<Amazontb>> GetAllAmazonCountries()
        {
            return await _ordertbdata.GetAllAmazonCountries();
        }

        public async Task UpdateAmazonCountry(Amazontb amazontb)
        {
             await _ordertbdata.UpdateAmazonCountry(amazontb);
        }
        public async Task<Amazontb> GetAmazonCountryById(int id)
        {
            return await _ordertbdata.GetAmazonCountryById(id);
        }

        public async Task InsertAmazonCountry(Amazontb amazontb)
        {
            await _ordertbdata.InsertAmazonCountry(amazontb);
        }




        //Orders

        
        public async Task<Orderstb> GetOrderById(int id)
        {
            return await _ordertbdata.GetOrderById(id);
        }
        public async Task<List<Orderstb>> GetAllOrders()
        {
            return await _ordertbdata.GetAllOrders();
        }

        public async Task InsertOrder(Orderstb orderstb)
        {
            await _ordertbdata.InsertOrder(orderstb);
        }

        public async Task DeleteOrderById(int id)
        {
            await _ordertbdata.DeleteOrderById(id);
        }

        public async Task UpdateOrder(Orderstb orderstb)
        {
            await _ordertbdata.UpdateOrder(orderstb);
        }

        public async Task<List<Orderstb>> GetAllOrdersByCreatedDate(DateTime d)
        {
           return await _ordertbdata.GetAllOrdersByCreatedDate(d);
        }

        public async Task<List<string>> GetAllUserNames()
        {
            return await _ordertbdata.GetAllUserNames();
        }
    }
       
 }

