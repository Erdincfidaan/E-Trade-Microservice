using ETrade.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailHandler(IRepository<OrderDetail> repository) 
        {
            _repository = repository; 
        }

        public async Task Handler(RemoveOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
