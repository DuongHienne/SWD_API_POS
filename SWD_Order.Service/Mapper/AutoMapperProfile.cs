using AutoMapper;
using SWD_Order.Repo.Entity;
using SWD_Order.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<Order, OrderResponeModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderDetails))
                 .ReverseMap(); 
            CreateMap<OrderDetail, OrderDetailRespone>().ReverseMap();

            CreateMap<Product, ProductResponse>()
                .ForMember(x => x.ListImages, opt => opt.MapFrom(src => src.Images))             
                .ReverseMap();
           CreateMap<Image, ImageModel>().ReverseMap();

            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Order, OrderResponeForGetAll>()
               .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderDetails))
                .ReverseMap();
            CreateMap<OrderDetail, OrderDetailResponeForGetAll>()
                .ReverseMap();
            CreateMap<Product, ModelsPro>()
                .ForMember(x => x.image , z => z.MapFrom(a => a.Images))
                .ReverseMap();
            CreateMap<Image, ModelsIg>().ReverseMap();
            CreateMap<Product, UpdateProduct>()
               
                .ReverseMap();
            CreateMap<Image, ImageUpdate>().ReverseMap();
            CreateMap<Product, AddProduct>()
                .ForMember(x => x.addImages, opt => opt.MapFrom(x => x.Images))
                .ReverseMap();
            CreateMap<Image, AddImage>().ReverseMap();
            CreateMap<OrderDetail, GetOrderSuccess>()
                .ForMember(x=> x.productN , opt => opt.MapFrom(x=> x.Product))
                .ForMember(x=> x.imageOrders, opt => opt.MapFrom(x => x.Product.Images))
                .ReverseMap();
            CreateMap<Image, imageOrder>().ReverseMap();
            CreateMap<Product, ProductN>().ReverseMap();
        }

    }
}
