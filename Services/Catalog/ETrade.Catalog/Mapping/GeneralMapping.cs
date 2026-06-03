using AutoMapper;
using ETrade.Catalog.Dtos.AboutDtos;
using ETrade.Catalog.Dtos.CategoryDtos;
using ETrade.Catalog.Dtos.ContactDtos;
using ETrade.Catalog.Dtos.FeatureSlidersDtos;
using ETrade.Catalog.Dtos.ProductDetailDtos;
using ETrade.Catalog.Dtos.ProductDtos;
using ETrade.Catalog.Dtos.ProductImageDtos;
using ETrade.Catalog.Entities;

namespace ETrade.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();

            CreateMap<ProductDetail,CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,GetByIdProductDetailDto>().ReverseMap();

            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,GetByIdProductDto>().ReverseMap();

            CreateMap<ProductImages,CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImages,ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImages,UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImages,GetByIdProductImageDto>().ReverseMap();

            CreateMap<Product,ResultProductsWithCategoryDto>().ReverseMap();

            CreateMap<FeatureSlider,CreateFeatureSlidersDto>().ReverseMap();
            CreateMap<FeatureSlider,ResultFeatureSlidersDto>().ReverseMap();
            CreateMap<FeatureSlider,UpdateFeatureSlidersDto>().ReverseMap();
            CreateMap<FeatureSlider,GetByIdFeatureSlidersDto>().ReverseMap();

            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
            CreateMap<About,GetByIdAboutDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();




        }
    }
}
