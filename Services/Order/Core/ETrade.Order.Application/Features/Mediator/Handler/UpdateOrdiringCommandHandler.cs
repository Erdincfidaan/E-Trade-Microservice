using ETrade.Order.Application.Features.Mediator.Command;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.Mediator.Handler
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.OrderingId);
            values.OrderDate = request.OrderDate;
            values.UserId = request.UserId;
            values.TotalPrice = request.TotalPrice;

            await _repository.UpdateAsync(values);
        }
    }
}
