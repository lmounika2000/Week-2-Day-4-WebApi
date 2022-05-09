using DataAccessLayer21.Models;
using DataAccessLAyer21;
using DomainLayer21;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer21
{
    public class OrdertbData : IOrdertbData
    {
        public int Id { get; private set; }

        public async Task<List<Orderstb>> GetAllOrders()
        {

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var amazontb = await dbContext.Orders.ToListAsync();

                List<Orderstb> domainModels = new List<Orderstb>();
                foreach (var amz in amazontb)
                {
                    domainModels.Add(new Orderstb
                    {
                        Id = amz.Id,
                        UserName = amz.UserName,
                        Cost = (int)amz.Cost,
                        ItemQty = amz.ItemQty,
                        CreatedDate = (DateTime)amz.CreatedDate,
                        UpdatedDate = (DateTime)amz.UpdatedDate,
                        AmazonID = (int)amz.AmazonId
                    });
                }
                return domainModels;
            }
        }

        public async Task InsertOrder(Orderstb orderstb)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Order
                {
                    UserName = orderstb.UserName,
                    Cost = orderstb.Cost,
                    ItemQty = orderstb.ItemQty,
                    CreatedDate = orderstb.CreatedDate,
                    UpdatedDate = orderstb.UpdatedDate,
                    AmazonId = orderstb.AmazonID
                };

                dbContext.Orders.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateOrder(Orderstb orderstb)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderstb.Id);

                findOrder.UserName = orderstb.UserName;
                findOrder.Cost = orderstb.Cost;
                findOrder.ItemQty = orderstb.ItemQty;

                dbContext.Orders.Update(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderById(int Id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
                dbContext.Orders.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Orderstb> GetOrderById(int id)
        {
            

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var orderstb = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

                Orderstb domainModel = new Orderstb
                {
                    AmazonID = orderstb.Id,
                    UserName = orderstb.UserName,
                    Cost = (int)orderstb.Cost,
                    ItemQty = orderstb.ItemQty,
                    CreatedDate = (DateTime)orderstb.CreatedDate,
                    UpdatedDate = (DateTime)orderstb.UpdatedDate,

                };

                return domainModel;
            }
        }

        

        public async Task<List<Amazontb>> GetAllAmazonCountries()
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var amazontb = await dbContext.Amazons.ToListAsync();

                List<Amazontb> domainModels = new List<Amazontb>();
                foreach (var amz in amazontb)
                {
                    domainModels.Add(new Amazontb
                    {
                        Id = amz.Id,
                        Name = amz.Name,

                    });
                }
                return domainModels;
            }
        }

        public async Task<Amazontb> GetAmazonCountryById(int id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var amazontb = await dbContext.Amazons.FirstOrDefaultAsync(x => x.Id == id);

                Amazontb domainModel = new Amazontb
                {

                    Name = amazontb.Name,


                };

                return domainModel;
            }
        }

        public async Task InsertAmazonCountry(Amazontb amazontb)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Amazon
                {
                    Id = amazontb.Id,
                    Name = amazontb.Name

                };

                dbContext.Amazons.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAmazonCountry(Amazontb amazontb)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Amazons.FirstOrDefaultAsync(x => x.Id == amazontb.Id);

                findOrder.Name = amazontb.Name;

                dbContext.Amazons.Update(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAmazonCountryById(int id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Amazons.FirstOrDefaultAsync(x => x.Id == Id);
                dbContext.Amazons.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Orderstb>> GetAllOrdersByCreatedDate(DateTime d)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var orderstb1 = await dbContext.Orders.Where(x => x.CreatedDate > d).ToListAsync();

                List<Orderstb> domainModel = new List<Orderstb>();
                foreach (var ord in orderstb1)
                {
                    domainModel.Add(new Orderstb
                    {
                        AmazonID = ord.Id,
                        UserName = ord.UserName,
                        Cost = (int)ord.Cost,
                        ItemQty = ord.ItemQty,
                        CreatedDate = (DateTime)ord.CreatedDate,
                        UpdatedDate = (DateTime)ord.UpdatedDate,

                    });
                }

                return domainModel;
            }
        }

        public async Task<List<string>> GetAllUserNames()
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {


                List<string> order = await dbContext.Orders.Select(x => x.UserName).ToListAsync();
                

                return order;
            }
        }
    }
}
