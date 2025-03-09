namespace API.Profiles
{
    using AutoMapper;
    using API.Entities;
    using API;

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap()
                .ForMember(dest => dest.InventoryStatus, opt => opt.MapFrom(src => src.InventoryStatus.ToString()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => new DateTimeOffset(src.CreatedAt).ToUnixTimeSeconds()))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => new DateTimeOffset(src.UpdatedAt).ToUnixTimeSeconds()));
        }
    }
}
