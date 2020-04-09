using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Data;
using TrainingProject.Data.Models;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models;

namespace TrainingProject.Domain.Logic.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IAppContext _servicesContext;
        private readonly IMapper _mapper;
        public OrderManager(IAppContext servicesContext, IMapper mapper)
        {
            _servicesContext = servicesContext;
            _mapper = mapper;
        }
        public async Task<Order> CreateOrderAsync(Order order, CancellationToken cancellationToken = default)
        {
            var newOrder = _mapper.Map<Order>(order);
            _servicesContext.Orders.Add(newOrder);
            await _servicesContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<Order>(newOrder);
        }

        public async Task DeleteOrderAsync(Guid order_id, CancellationToken cancellationToken = default)
        {
            var order = await _servicesContext.Orders.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.IdOrder == order_id, cancellationToken);
            if (order != null)
            {           
                _servicesContext.Orders.Remove(order);
                await _servicesContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<Order> GetOrderAsync(Guid order_id, CancellationToken cancellationToken = default)
        {
            var order = await _servicesContext.Orders.FirstOrDefaultAsync(x => x.IdOrder == order_id, cancellationToken);
            return _mapper.Map<Order>(order);
        }

        public async Task<Order[]> GetOrdersAsync(string search, int? fromIndex = null, int? toIndex = null, CancellationToken cancellationToken = default)
        {
            var query = _servicesContext.Orders.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    x.Title.ToLower().Contains(search.ToLower()) ||
                    x.Description.ToLower().Contains(search.ToLower()));
            }
            if (fromIndex.HasValue)
            {
                query = query.Skip(fromIndex.Value);
            }
            query = query.OrderBy(x => x.Title);
            var total = await query.CountAsync(cancellationToken);
            if (fromIndex.HasValue && toIndex.HasValue)
            {
                query = query.Skip(fromIndex.Value).Take(toIndex.Value - fromIndex.Value + 1);
            }

            return await _mapper.ProjectTo<Order>(query).ToArrayAsync(cancellationToken);
            
        }

        public Task<Order> UpdateOrderAsync(Order order, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
