using AutoMapper;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints;
using Microsoft.eShopWeb.PublicApi.CatalogMaterialEndpoints;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints;

namespace Microsoft.eShopWeb.PublicApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogItem, CatalogItemDto>();
            CreateMap<CatalogType, CatalogTypeDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
            CreateMap<CatalogBrand, CatalogBrandDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Brand));

            //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
            CreateMap<CatalogMaterial, CatalogMaterialDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Material));
        }
    }
}
