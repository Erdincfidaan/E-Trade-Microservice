using AutoMapper;
using ETrade.Cargo.DtoLayer.Dtos.CargoCompanyDTO;
using ETrade.Cargo.DtoLayer.Dtos.CargoCustomerDTO;
using ETrade.Cargo.DtoLayer.Dtos.CargoDetailDto;
using ETrade.Cargo.DtoLayer.Dtos.CargoOperationDTO;
using ETrade.Cargo.EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Cargo.EntitiyLayer.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            //CreateMap<Source, Destination>();
            CreateMap<CargoCompanyCreateDto,CargoCompany>().ReverseMap();
            CreateMap<CargoCompanyUpdateDto,CargoCompany>().ReverseMap();
            CreateMap<CargoCustomerCreateDto,CargoCustomer>().ReverseMap(); 
            CreateMap<CargoCustomerUpdateDto,CargoCustomer>().ReverseMap();
            CreateMap<CargoOperationCreateDto,CargoOperation>().ReverseMap();
            CreateMap<CargoOperationUpdateDto,CargoOperation>().ReverseMap();
            CreateMap<CargoDetailCreateDto,CargoDetail>().ReverseMap();
            CreateMap<CargoDetailUpdateDto,CargoDetail>().ReverseMap();
        }
    }
}
