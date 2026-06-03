using ETrade.Order.Application.Features.CQRS.Commands.AdressCommands;
using ETrade.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using ETrade.Order.Application.Features.CQRS.Queries.AdressQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly CreateAdressCommandHandler _createHandler;
        private readonly GetAdressByIdQueryHandler _getAdressByIdQueryHandler;
        private readonly GetAdressQueryHandler _getAdressQueryHandler;
        private readonly UpdateAdressCommandHandler _updateAdressCommandHandler;
        private readonly RemoveAdressCommandHandler _removeAdressCommandHandler;
        public AdressController(CreateAdressCommandHandler createHandler , GetAdressByIdQueryHandler getAdressByIdQueryHandler,GetAdressQueryHandler getAdressQueryHandler,UpdateAdressCommandHandler updateAdressCommandHandler,RemoveAdressCommandHandler removeAdressCommandHandler)
        {
            _createHandler = createHandler;
            _getAdressByIdQueryHandler = getAdressByIdQueryHandler;
            _getAdressQueryHandler= getAdressQueryHandler;
            _updateAdressCommandHandler= updateAdressCommandHandler;
            _removeAdressCommandHandler= removeAdressCommandHandler;

        }

        [HttpPost]
        public async Task<IActionResult> CreateAdress(CreateAdressCommand command)
        {
            await _createHandler.Handle(command);
            return Ok("Adres bilgisi başarıyla eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAdress(int id)
        {
            var values =await _getAdressByIdQueryHandler.Handle(new GetAdressByIdQuery(id));
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetAdressList()
        {
            var values= await _getAdressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAdress(int id)
        {
            await _removeAdressCommandHandler.Handle(new RemoveAdressCommand(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> AdressUpdate(UpdateAdressCommand updateAdressCommand)
        {
            await _updateAdressCommandHandler.Handle(updateAdressCommand);
            return Ok();

        }


    }
}
