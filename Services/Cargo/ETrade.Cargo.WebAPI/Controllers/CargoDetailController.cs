using AutoMapper;
using ETrade.Cargo.Business.Abstract;
using ETrade.Cargo.DtoLayer.Dtos.CargoDetailDto;
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
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IMapper _mapper;

        public CargoDetailController(ICargoDetailService cargoDetailService, IMapper mapper)
        {
            _cargoDetailService = cargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCargoDetail()
        {
            var result = _cargoDetailService.TGetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdCargoDetail(int id)
        {
            var result = _cargoDetailService.TGetById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CargoDetailCreateDto cargoDetailCreateDto)
        {
            var entity = _mapper.Map<CargoDetail>(cargoDetailCreateDto);
            _cargoDetailService.TInsert(entity);
            return Ok("Başarıyla oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(CargoDetailUpdateDto cargoDetailUpdateDto)
        {
            var entity = _mapper.Map<CargoDetail>(cargoDetailUpdateDto);
            _cargoDetailService.TUpdate(entity);
            return Ok("Güncellem Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Silme başarılı");
        }
    }
}
