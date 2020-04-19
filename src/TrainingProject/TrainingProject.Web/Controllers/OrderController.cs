using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingProject.Data;
using TrainingProject.Data.Models;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        AppContext _appContext;
        public OrderController(AppContext context)
        {
            _appContext = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _appContext.Orders.ToListAsync();
        }
        [Authorize(Roles = "Orderer")]
        [HttpGet("/myorders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetUserOrders()
        {
            return await _appContext.Orders.Where(x=>x.IdUser==_appContext.Users.First(x=>x.Name==User.Identity.Name).IdUser).ToListAsync();
        }

        [HttpGet("/category")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCategory(Categories category)
        {
            List<Order> orders = await _appContext.Orders.Where(x=>x.IdCategory==category.IdCategory).ToListAsync();
            return orders;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            Order order = await _appContext.Orders.FirstOrDefaultAsync(x => x.IdOrder == id);
            if (order == null)
                return NotFound();
            return new ObjectResult(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            _appContext.Orders.Add(order);
            await _appContext.SaveChangesAsync();
            return Ok(order);
        } 

        [HttpPut]
        public async Task<ActionResult<Order>> EditOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            if (!_appContext.Orders.Any(x => x.IdOrder == order.IdOrder))
            {
                return NotFound();
            }

            _appContext.Update(order);
            await _appContext.SaveChangesAsync();
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(Guid id)
        {
            Order order = _appContext.Orders.FirstOrDefault(x => x.IdOrder == id);
            if (order == null)
            {
                return NotFound();
            }
            _appContext.Orders.Remove(order);
            await _appContext.SaveChangesAsync();
            return Ok(order);
        }
    }
}