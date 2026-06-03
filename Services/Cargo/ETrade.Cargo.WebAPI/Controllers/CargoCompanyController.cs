using AutoMapper;
using ETrade.Cargo.Business.Abstract;
using ETrade.Cargo.DtoLayer.Dtos.CargoCompanyDTO;
using ETrade.Cargo.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService,IMapper mapper)
        {
            _cargoCompanyService = cargoCompanyService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCargoCompanies()
        {
            var result = _cargoCompanyService.TGetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var result = _cargoCompanyService.TGetById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CargoCompanyCreateDto cargoCompanyCreateDto)
        {
            var entity= _mapper.Map<CargoCompany>(cargoCompanyCreateDto);
            _cargoCompanyService.TInsert(entity);
            return Ok("Başarıyla Oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateCargoCompany(CargoCompanyUpdateDto cargoCompanyUpdateDto)
        {
            var entity=_mapper.Map<CargoCompany>(cargoCompanyUpdateDto);
            _cargoCompanyService.TUpdate(entity);
            return Ok("Güncelleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Başarıyla Silindi");
        }


    }
}
