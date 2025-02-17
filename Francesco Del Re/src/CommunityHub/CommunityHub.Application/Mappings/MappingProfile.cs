using AutoMapper;
using CommunityHub.Application.DTOs;
using CommunityHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.Application.Mappings
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserDetailDto>();

            CreateMap<Booking, BookingDto>();
            CreateMap<CreateBookingDto, BookingDto>();

            CreateMap<Webinar, WebinarDto>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.DateRange!.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.DateRange!.EndDate));

            CreateMap<Webinar, WebinarDetailDto>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.DateRange!.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.DateRange!.EndDate));
        }
    }
}
