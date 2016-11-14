using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;
namespace ZzaDesktop.Services
{
    public class OrdersRepository : IOrdersRepository
    {
        ZzaDbContext _context = new ZzaDbContext();

        public async Task<List<Order>> GetOrdersForCustomersAsync(Guid customerId)
        {
            return await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            //if (!_context.Orders.Local.Any(o => o.Id == order.Id))
            //{
            //    _context.Orders.Attach(order);
            //}
            //_context.Entry(order).State = EntityState.Modified;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            //    var order = _context.Orders.Include("OrderItems").Include("OrderItems.OrderItemOptions").FirstOrDefault(o => o.Id == orderId);
            //    if (order != null)
            //    {
            //        foreach (OrderItem item in order.OrderItems)
            //        {
            //            foreach (var orderItemOption in item.Options)
            //            {
            //                _context.OrderItemOptions.Remove(orderItemOption);
            //            }
            //            _context.OrderItems.Remove(item);
            //        }
            //        _context.Orders.Remove(order);
            //    }
            //    await _context.SaveChangesAsync();
            //    scope.Complete();
            //}

            // TransactionScope is not in EF core and having trouble with the Include extension method.  Probably need to create some
            // kind of algorithm that loops and puts the OrderItemOptions into the Orderitems into the Orders.
            await Task.Run(() => true);
            throw new NotImplementedException();
        }


        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<ProductOption>> GetProductOptionsAsync()
        {
            return await _context.ProductOptions.ToListAsync();
        }

        public async Task<List<ProductSize>> GetProductSizesAsync()
        {
            return await _context.ProductSizes.ToListAsync();
        }

        public async Task<List<OrderStatus>> GetOrderStatusesAsync()
        {
            return await _context.OrderStatuses.ToListAsync();
        }
    }
}
