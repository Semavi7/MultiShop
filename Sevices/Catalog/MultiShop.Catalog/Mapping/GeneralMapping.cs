using AutoMapper;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Category, ResultProductDto>().ReverseMap();
            CreateMap<Category, CreateProductDto>().ReverseMap();
            CreateMap<Category, UpdateProductDto>().ReverseMap();
            CreateMap<Category, GetByIdProductDto>().ReverseMap();

            CreateMap<Category, ResultProductDetailDto>().ReverseMap();
            CreateMap<Category, CreateProductDetailDto>().ReverseMap();
            CreateMap<Category, UpdateProductDetailDto>().ReverseMap();
            CreateMap<Category, GetByIdProductDetailDto>().ReverseMap();

            CreateMap<Category, ResultProductImageDto>().ReverseMap();
            CreateMap<Category, CreateProductImageDto>().ReverseMap();
            CreateMap<Category, UpdateProductImageDto>().ReverseMap();
            CreateMap<Category, GetByIdProductImageDto>().ReverseMap();
        }
    }
}
