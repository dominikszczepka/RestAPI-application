using appRestAPI.Contracts.Dtos;
using appRestAPI.Contracts.Orders;
using appRestAPI.Models;
using AutoMapper;

namespace appRestAPI.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => DateOnly.Parse(src.OrderDate)))
                .ForMember(dest => dest.ShipmentDate, opt => opt.MapFrom(src => DateOnly.Parse(src.ShipmentDate!)));
            CreateMap<Order, OrderResult>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.ShipmentDate, opt => opt.MapFrom(src => src.ShipmentDate!.Value.ToString("dd.MM.yyyy")));
        }
    }
}
