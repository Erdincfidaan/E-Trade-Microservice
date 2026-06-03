using ETrade.Order.Application.Features.CQRS.Queries.AdressQueries;
using ETrade.Order.Application.Features.CQRS.Results.AdressResults;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class GetAdressByIdQueryHandler
    {
        private readonly IRepository<Adress> _repository;
        public GetAdressByIdQueryHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }

        public async Task<GetAdressByIdQueryResult> Handle(GetAdressByIdQuery query)
        {
            var values= await _repository.GetByIdAsync(query.Id);
            return new GetAdressByIdQueryResult

            {
                AdressId=values.AdressId,
                City=values.City,
                Detail=values.Detail,
                District=values.District,
                UserId=values.UserId,



             };
                
             
        }
            
    }
}
