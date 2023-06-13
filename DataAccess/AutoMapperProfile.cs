using AutoMapper;
using DataAccess.Models;

namespace DataAccess
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BusinessObject.Member, Member>();
            CreateMap<BusinessObject.Product, Product>();
            CreateMap<BusinessObject.Order, Order>();
            CreateMap<BusinessObject.OrderDetail, OrderDetail>();
            CreateMap<BusinessObject.Category, Category>();
            CreateMap<Member, BusinessObject.Member>();
            CreateMap<Product, BusinessObject.Product>();
            CreateMap<Order, BusinessObject.Order>();
            CreateMap<OrderDetail, BusinessObject.OrderDetail>();
            CreateMap<Category, BusinessObject.Category>();
        }
    }
}
