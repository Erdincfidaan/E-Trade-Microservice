using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.Mediator.Command
{
    public class RemoveOrderingCommnad:IRequest
    {
        public int Id { get; set; }

        public RemoveOrderingCommnad(int id) 
        {
            Id = id;
        }
    }
}
