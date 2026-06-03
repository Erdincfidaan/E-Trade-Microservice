using ETrade.Order.Application.Features.CQRS.Results.AdressResults;
using ETrade.Order.Application.Features.Mediator.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.Mediator.Query
{
    public class GetOrderingQuery: IRequest<List<GetOrderingQueryResult>>
    {
        
    }
}
