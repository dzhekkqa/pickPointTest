using Microsoft.AspNetCore.Mvc;
using pickPointTest.Contracts.Requests;
using pickPointTest.Models;
using pickPointTest.Services;
using System;
using System.Threading.Tasks;

namespace pickPointTest.Controllers
{
    public class OrderOperationController : Controller
    {
        private IOrderService _orderService;

        public OrderOperationController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("api/CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest order)
        {
            try
            {
                if (order.orderList == null || order.orderList.Length > 10)
                    return BadRequest("В одном заказе может быть только 10 товаров");
                int counter = 0;
                foreach (var orderItem in order.orderList)
                {
                    if (orderItem.Trim() == null)
                        counter++;
                }
                if (counter > 0)
                    return BadRequest("Товары не могут быть пустыми!");
                var newOrder = new Order
                {
                    orderList = order.orderList,
                    orderStatus = order.orderStatus,
                    postamatNumber = order.postamatNumber,
                    customerPhoneNumber = order.customerPhoneNumber,
                    customerFio = order.customerFio,
                    price = order.orderPrice
                };
                var added = await _orderService.CreateOrder(newOrder);
                if (added != false)
                    return Ok("Заказ создан!");
                return BadRequest("Произошла ошибка!");
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("api/UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequest uor)
        {
            try
            {
                var result = await _orderService.UpdateOrder(uor);
                if (result != false)
                    return Ok("Заказ изменён!");
                return BadRequest();
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("api/GetOrderInfo")]
        public async Task<IActionResult> GetOrderInfo(OrderInfoRequest oir)
        {
            try
            {
                var result = await _orderService.GetOrderInfo(oir);
                if (result != null)
                    return Ok(result);
                return NotFound("Заказ не найден!");
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("api/CancelOrder")]
        public async Task<IActionResult> CancelOrder(CancelOrderRequest cor)
        {
            try
            {
                var result = await _orderService.CancelOrder(cor);
                if (result != false)
                    return Ok("Заказ отменён");
                return BadRequest("Произошла ошибка");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
