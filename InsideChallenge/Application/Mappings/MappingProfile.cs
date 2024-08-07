using AutoMapper;
using InsideChallenge.Application.Features.Orders.Commands.CreateOrder;
using InsideChallenge.Application.Features.Products.Commands.CreateProduct;
using InsideChallenge.Application.Features.Products.Commands.DeleteProduct;
using InsideChallenge.Application.Features.Products.Commands.UpdateProduct;
using InsideChallenge.Application.Persistence;
using InsideChallenge.Domain.Entities;

namespace InsideChallenge.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>()
    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            CreateMap<CreateProductCommand, Product>();
            CreateMap<DeleteProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<CreateOrderCommand, Order>();
        }
    }
}
