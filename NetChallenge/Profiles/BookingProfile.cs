using AutoMapper;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<BookOfficeRequest, Booking>()
            .ForMember(dest => dest.Office.Name, opt => opt.MapFrom(src => src.OfficeName));
    }
}
