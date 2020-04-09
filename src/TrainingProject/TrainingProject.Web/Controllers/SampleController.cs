using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Data.Models;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Managers;
using TrainingProject.Domain.Logic.Models;

namespace TrainingProject.Web.Controllers
{
    [ApiController]
    [Route("api/sample")]
    public class SampleController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public SampleController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] string search,
            [FromQuery] int? fromIndex = default,
            [FromQuery] int? toIndex = default,
            CancellationToken cancellationToken = default)
        {
            var result = await _orderManager.GetOrdersAsync(search, fromIndex, toIndex, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetAsync(
            Guid productId,
            CancellationToken cancellationToken = default)
        {
            var result = await _orderManager.GetOrderAsync(productId, cancellationToken);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync(
            Order product,
            CancellationToken cancellationToken = default)
        {
            var result = await _orderManager.CreateOrderAsync(product, cancellationToken);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync(
            Order product,
            CancellationToken cancellationToken = default)
        {
            var result = await _orderManager.UpdateOrderAsync(product, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteAsync(
            Guid productId,
            [FromQuery] bool force = false,
            CancellationToken cancellationToken = default)
        {
            await _orderManager.DeleteOrderAsync(productId, cancellationToken);
            return Ok();
        }
    }
}
