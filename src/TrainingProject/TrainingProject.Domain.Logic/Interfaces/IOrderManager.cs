using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Data.Models;
using TrainingProject.Domain.Logic.Models;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IOrderManager
    {
        Task<Order[]> GetOrdersAsync(string search, int? fromIndex = default, int? toIndex = default, CancellationToken cancellationToken = default);
        Task<Order> GetOrderAsync(Guid orderId, CancellationToken cancellationToken = default);
        Task<Order> CreateOrderAsync(Order order, CancellationToken cancellationToken = default);
        Task<Order> UpdateOrderAsync(Order order, CancellationToken cancellationToken = default);
        Task DeleteOrderAsync(Guid orderId, CancellationToken cancellationToken = default);

    }
}
