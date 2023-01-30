using Caravan.Service.Common.Utils;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tsp;

namespace Caravan.Web.Areas.Administrator.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly int _pageSize = 20;

        public OrdersController(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        public async Task<ViewResult> Index(int page = 1)
        {
            var orders = await _orderService.GetAllAsync(new PaginationParams(page, _pageSize));
            return View(orders);
        }
    }
}
