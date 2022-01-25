using Microsoft.AspNetCore.Mvc;
using pickPointTest.Contracts.Requests;
using pickPointTest.Models;
using System.Threading.Tasks;

namespace pickPointTest.Services
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(Order order);

        Task<bool> CancelOrder(CancelOrderRequest cor);

        Task<bool> UpdateOrder(UpdateOrderRequest uor);

        Task<Order> GetOrderInfo(OrderInfoRequest oir);
    }
}
