﻿using AutoMapper;
using FurnitureStoreBE.DTOs.Response.OrderResponse;
using FurnitureStoreBE.DTOs.Response.BrandResponse;
using FurnitureStoreBE.DTOs.Response.ProductResponse;
using FurnitureStoreBE.DTOs.Response.UserResponse;
using FurnitureStoreBE.Models;
using Microsoft.CodeAnalysis;
using FurnitureStoreBE.DTOs.Response.CouponResponse;
using FurnitureStoreBE.DTOs.Response.ReviewResponse;
using FurnitureStoreBE.DTOs.Response.ReplyResponses;
using FurnitureStoreBE.DTOs.Response.QuestionResponse;
namespace FurnitureStoreBE.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AspNetTypeClaims, TypeClaimsResponse>();
            CreateMap<User,  UserResponse>();
            CreateMap<Address, AddressResponse>();
            CreateMap<Color, ColorResponse>();
            CreateMap<Size, SizeResponse>();
            CreateMap<Brand, BrandResponse>().ForMember(dest => dest.ImageSource, opt => opt.MapFrom(src => src.Asset.URL));
            CreateMap<Category, CategoryResponse>().ForMember(dest => dest.ImageSource, opt => opt.MapFrom(src => src.Asset.URL));
         

            CreateMap<ProductVariant, ProductVariantResponse>()
               .ForMember(dest => dest.ColorName, otp => otp.MapFrom(src => src.Color.ColorName))
               .ForMember(dest => dest.SizeName, otp => otp.MapFrom(src => src.Size.SizeName))
               .ForMember(dest => dest.Quantity, otp => otp.MapFrom(src => src.Quantity))
               .ForMember(dest => dest.Price, otp => otp.MapFrom(src => src.Price))
               .ForMember(dest => dest.ImageSource, otp => otp.MapFrom(src => src.Assets.Select(a => a.URL).ToList()));

            CreateMap<Product, ProductResponse>().ForMember(dest => dest.ImageSource, otp => otp.MapFrom(src => src.Asset.URL))
                .ForMember(dest => dest.CategoryName, otp => otp.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.BrandName, otp => otp.MapFrom(src => src.Brand.BrandName))
                .ForMember(dest => dest.DisplayPrice, otp => otp.MapFrom(src => $"{src.MinPrice} - {src.MaxPrice}"))
                .ForMember(dest => dest.ProductVariants, otp => otp.MapFrom(src => src.ProductVariants));

            CreateMap<OrderItem, OrderItemResponse>()
                .ForMember(dest => dest.ColorName, otp => otp.MapFrom(src => src.Color.ColorName))
                .ForMember(dest => dest.SizeName, otp => otp.MapFrom(src => src.Size.SizeName))
                .ForMember(dest => dest.ProductName, otp => otp.MapFrom(src => src.Product.ProductName));

            CreateMap<Coupon, CouponResponse>()
                .ForMember(dest => dest.ImageSource, otp => otp.MapFrom(src => src.Asset.URL))
                .ForMember(dest => dest.ECouponStatus, otp => otp.MapFrom(src => src.ECouponStatus.ToString()))
                .ForMember(dest => dest.ECouponType, otp => otp.MapFrom(src => src.ECouponType.ToString()));
           
            CreateMap<Reply, ReplyResponse>()
              .ForMember(dest => dest.FullName, otp => otp.MapFrom(src => src.User.FullName))
              .ForMember(dest => dest.Role, otp => otp.MapFrom(src => src.User.Role));
            
            CreateMap<Review, ReviewResponse>()
                .ForMember(dest => dest.ImagesSource, otp => otp.MapFrom(src => src.Asset.Select(a => a.URL).ToList()))
                .ForMember(dest => dest.FullName, otp => otp.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.Role, otp => otp.MapFrom(src => src.User.Role))
                .ForMember(dest => dest.UpdatedDate, otp => otp.MapFrom(src => src.UpdatedDate))
                .ForMember(dest => dest.ReplyResponses, otp => otp.MapFrom(src => src.Reply));

            CreateMap<Question, QuestionResponse>()
                .ForMember(dest => dest.FullName, otp => otp.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.Role, otp => otp.MapFrom(src => src.User.Role))
                .ForMember(dest => dest.UpdatedDate, otp => otp.MapFrom(src => src.UpdatedDate))
                .ForMember(dest => dest.ReplyResponses, otp => otp.MapFrom(src => src.Reply));

            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.PaymentMethod, otp => otp.MapFrom(src => src.PaymentMethod.ToString()))
                .ForMember(dest => dest.OrderStatus, otp => otp.MapFrom(src => src.OrderStatus.ToString()))
                .ForMember(dest => dest.OrderItemResponses, otp => otp.MapFrom(src => src.OrderItems));

        }
    }
}
