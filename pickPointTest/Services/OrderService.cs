using pickPointTest.Data;
using pickPointTest.Models;
using System.Threading.Tasks;
using pickPointTest.Contracts.Requests;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace pickPointTest.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;

        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateOrder(Order order)
        {
            var postamat = await _dataContext.Postamats
                .Where(x => x.pNumber == order.postamatNumber && x.pStatus == true)
                .SingleOrDefaultAsync();
            if (postamat == null)
                return false;

            await _dataContext.Orders.AddAsync(order);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> CancelOrder(CancelOrderRequest cor)
        {
            var order = await _dataContext.Orders
                        .Where(x => x.orderNumber == cor.orderNumber)
                        .SingleOrDefaultAsync();

            order.orderStatus = OrderStatus.Cancelled;
            _dataContext.Update(order);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public Order objectHasChanged(Order oldOrder, UpdateOrderRequest newOrder)
        {
            if (oldOrder.orderList != newOrder.orderList && newOrder.orderList != null)
                oldOrder.orderList = newOrder.orderList;
            if (oldOrder.price != newOrder.price && newOrder.price != null)
                oldOrder.price = (decimal)newOrder.price;
            if (oldOrder.customerPhoneNumber != newOrder.customerPhoneNumber && newOrder.customerPhoneNumber != null)
                oldOrder.customerPhoneNumber = newOrder.customerPhoneNumber;
            if (oldOrder.customerFio != newOrder.customerFio && newOrder.customerFio != null)
                oldOrder.customerFio = newOrder.customerFio;
            return oldOrder;
        }

        public async Task<bool> UpdateOrder(UpdateOrderRequest uor)
        {
            var order = await _dataContext.Orders
                        .Where(x => x.orderNumber == uor.orderNumber)
                        .SingleOrDefaultAsync();
            if (order == null)
                return false;
            if (uor.orderList == null || uor.orderList.Length > 10)
                return false;

            var changedOrder = objectHasChanged(order, uor);
            _dataContext.Update(changedOrder);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<Order> GetOrderInfo(OrderInfoRequest oir)
        {
            return await _dataContext.Orders
                .Where(x => x.orderNumber == oir.orderNumber)
                .SingleOrDefaultAsync();
        }
    }
}
