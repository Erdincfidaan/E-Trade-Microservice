using ETrade.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ETrade.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using ETrade.Order.Application.Features.CQRS.Results.OrderDetailResults;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailQueryResult> Handler(GetOrderDetailByIdQueries query)
        {
            var values= await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailQueryResult
            {
                OrderDetailId = values.OrderDetailId,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductAmount = values.ProductAmount,
                ProductTotalPrice = values.ProductTotalPrice,
                OrderingId = values.OrderingId,

            };
            
        }
    }
}
