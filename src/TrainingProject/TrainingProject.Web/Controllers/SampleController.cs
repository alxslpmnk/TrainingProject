using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Managers;
using TrainingProject.Domain.Logic.Models;

namespace TrainingProject.Web.Controllers
{
    [ApiController]
    [Route("api/sample")]
    public class SampleController : ControllerBase
    {
        private readonly IOrderManager _ordertManager;

        public SampleController(IOrderManager orderManager)
        {
            _ordertManager = orderManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] string search,
            [FromQuery] int? fromIndex = default,
            [FromQuery] int? toIndex = default,
            CancellationToken cancellationToken = default)
        {
            var result = await _ordertManager.GetOrdersAsync(search, fromIndex, toIndex, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetAsync(
            Guid productId,
            CancellationToken cancellationToken = default)
        {
            var result = await _ordertManager.GetOrderAsync(productId, cancellationToken);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync(
            OrderDTO product,
            CancellationToken cancellationToken = default)
        {
            var result = await _ordertManager.CreateOrderAsync(product, cancellationToken);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync(
            OrderDTO product,
            CancellationToken cancellationToken = default)
        {
            var result = await _ordertManager.UpdateOrderAsync(product, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteAsync(
            Guid productId,
            [FromQuery] bool force = false,
            CancellationToken cancellationToken = default)
        {
            await _ordertManager.DeleteOrderAsync(productId, force, cancellationToken);
            return Ok();
        }
    }
}
