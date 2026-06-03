using ETrade.Order.Application.Features.CQRS.Commands.AdressCommands;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ETrade.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class UpdateAdressCommandHandler
    {
        private readonly IRepository<Adress> _repository;//dependency ınjection adress nesnesini alır
        public UpdateAdressCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }
        
        public async Task Handle(UpdateAdressCommand updateAdressCommand)
        {
            var value = await _repository.GetByIdAsync(updateAdressCommand.AdressId);
            value.Detail=updateAdressCommand.Detail;
            value.District=updateAdressCommand.District;
            value.City=updateAdressCommand.City;
            value.UserId=updateAdressCommand.UserId;
            await _repository.UpdateAsync(value);
        }
    }
}
