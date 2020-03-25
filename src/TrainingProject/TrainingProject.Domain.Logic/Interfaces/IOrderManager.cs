using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Models;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IOrderManager
    {
        Task<OrderDTO> GetOrdersAsync(string search, int? fromIndex = default, int? toIndex = default, CancellationToken cancellationToken = default);
        Task<OrderDTO> GetOrderAsync(Guid productId, CancellationToken cancellationToken = default);
        Task<OrderDTO> CreateOrderAsync(OrderDTO product, CancellationToken cancellationToken = default);
        Task<OrderDTO> UpdateOrderAsync(OrderDTO product, CancellationToken cancellationToken = default);
        Task DeleteOrderAsync(Guid productId, bool force, CancellationToken cancellationToken = default);

    }
}
