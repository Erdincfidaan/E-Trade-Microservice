using ETrade.Order.Application.Features.CQRS.Results.OrderDetailResults;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handler()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
                {
                    OrderDetailId = x.OrderDetailId,
                    ProductAmount = x.ProductAmount,
                    ProductName = x.ProductName,
                    OrderingId = x.OrderingId,
                    ProductPrice = x.ProductPrice,
                    ProductTotalPrice = x.ProductTotalPrice,
                    ProductId = x.ProductId,

                }
             ).ToList();
        }
    }
}
