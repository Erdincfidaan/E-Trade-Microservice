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
    public class RemoveOrderingCommandHandler:IRequestHandler<RemoveOrderingCommnad>
    {
        private readonly IRepository<Ordering> _repository;
        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderingCommnad request,CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
