using AutoMapper;
using ETrade.Cargo.Business.Abstract;
using ETrade.Cargo.DtoLayer.Dtos.CargoCompanyDTO;
using ETrade.Cargo.DtoLayer.Dtos.CargoCustomerDTO;
using ETrade.Cargo.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IMapper _mapper;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService, IMapper mapper)
        {
            _cargoCustomerService = cargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCargoCustomer()
        {
            var result = _cargoCustomerService.TGetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdCargoCustomer(int id)
        {
            var result = _cargoCustomerService.TGetById(id);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(CargoCustomerUpdateDto cargoCustomerUpdateDto)
        {
            var entity= _mapper.Map<CargoCustomer>(cargoCustomerUpdateDto);
            _cargoCustomerService.TUpdate(entity);
            return Ok("Başaarıyla Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteByIdCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Başarıyla silindi");
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CargoCustomerCreateDto cargoCustomerCreateDto)
        {
            var entity = _mapper.Map<CargoCustomer>(cargoCustomerCreateDto);
            _cargoCustomerService.TInsert(entity);
            return Ok("Başarıyla Eklendi");
        }
    }
}
