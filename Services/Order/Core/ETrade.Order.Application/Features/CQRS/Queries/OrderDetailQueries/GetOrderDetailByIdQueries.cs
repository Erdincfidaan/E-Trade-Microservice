using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQueries
    {
        public int Id { get; set; }

        public GetOrderDetailByIdQueries(int id) 
        {
            Id = id;
        }
        
    }
}
