using AutoMapper;
using ETrade.Cargo.Business.Abstract;
using ETrade.Cargo.DtoLayer.Dtos.CargoOperationDTO;
using ETrade.Cargo.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationController(ICargoOperationService cargoOperationService, IMapper mapper)
        {
            _cargoOperationService = cargoOperationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCargoOperation()
        {
            var result=_cargoOperationService.TGetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdCargoOperation(int id)
        {
            var result = _cargoOperationService.TGetById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CargoOperationCreateDto cargoOperationCreateDto)
        {
            var entity= _mapper.Map<CargoOperation>(cargoOperationCreateDto);
            _cargoOperationService.TInsert(entity);
            return Ok("Başarıyla oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(CargoOperationUpdateDto cargoOperationUpdateDto)
        {
            var entity = _mapper.Map<CargoOperation>(cargoOperationUpdateDto);
            _cargoOperationService.TUpdate(entity);
            return Ok("Güncellem Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCaargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Silme başarılı");
        }
    }
}
