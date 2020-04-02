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
        Task<OrderDTO[]> GetOrdersAsync(string search, int? fromIndex = default, int? toIndex = default, CancellationToken cancellationToken = default);
        Task<OrderDTO> GetOrderAsync(Guid orderId, CancellationToken cancellationToken = default);
        Task<OrderDTO> CreateOrderAsync(OrderDTO order, CancellationToken cancellationToken = default);
        Task<OrderDTO> UpdateOrderAsync(OrderDTO order, CancellationToken cancellationToken = default);
        Task DeleteOrderAsync(Guid orderId, bool force, CancellationToken cancellationToken = default);

    }
}
