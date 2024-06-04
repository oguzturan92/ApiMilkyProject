using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Milky.Dto.AboutDtos;
using Milky.Dto.AddressDtos;
using Milky.Dto.BannerDtos;
using Milky.Dto.MessageDtos;
using Milky.Dto.ProductDtos;
using Milky.Dto.ServiceDtos;
using Milky.Dto.SiteSocialMediaDtos;
using Milky.Dto.SliderDtos;
using Milky.Dto.SocialMediaDtos;
using Milky.Dto.SubscribeDtos;
using Milky.Dto.TeamDtos;
using Milky.Dto.TestimonialDtos;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AboutCreateDto, About>().ReverseMap();
            CreateMap<AboutUpdateDto, About>().ReverseMap();

            CreateMap<AddressCreateDto, Address>().ReverseMap();
            CreateMap<AddressUpdateDto, Address>().ReverseMap();

            CreateMap<BannerCreateDto, Banner>().ReverseMap();
            CreateMap<BannerUpdateDto, Banner>().ReverseMap();

            CreateMap<MessageCreateDto, Message>().ReverseMap();

            CreateMap<ProductCreateDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();

            CreateMap<ServiceCreateDto, Service>().ReverseMap();
            CreateMap<ServiceUpdateDto, Service>().ReverseMap();

            CreateMap<SiteSocialMediaCreateDto, SiteSocialMedia>().ReverseMap();
            CreateMap<SiteSocialMediaUpdateDto, SiteSocialMedia>().ReverseMap();

            CreateMap<SliderCreateDto, Slider>().ReverseMap();
            CreateMap<SliderUpdateDto, Slider>().ReverseMap();

            CreateMap<SocialMediaCreateDto, SocialMedia>().ReverseMap();
            CreateMap<SocialMediaUpdateDto, SocialMedia>().ReverseMap();

            CreateMap<SubscribeCreateDto, Subscribe>().ReverseMap();

            CreateMap<TeamCreateDto, Team>().ReverseMap();
            CreateMap<TeamUpdateDto, Team>().ReverseMap();

            CreateMap<TestimonialCreateDto, Testimonial>().ReverseMap();
            CreateMap<TestimonialUpdateDto, Testimonial>().ReverseMap();
        }
    }
}