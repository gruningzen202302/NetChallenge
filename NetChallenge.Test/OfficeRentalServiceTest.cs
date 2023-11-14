using NetChallenge.Abstractions;
using NetChallenge.Infrastructure;
using AutoMapper;
namespace NetChallenge.Test
{
    public class OfficeRentalServiceTest
    {
        protected OfficeRentalService Service;
        protected ILocationRepository LocationRepository;
        protected IOfficeRepository OfficeRepository;
        protected IBookingRepository BookingRepository;
        private IMapper mapper;

        public OfficeRentalServiceTest()
        {
            LocationRepository = new LocationRepository();
            OfficeRepository = new OfficeRepository();
            BookingRepository = new BookingRepository();
            Service = new OfficeRentalService(LocationRepository, OfficeRepository, BookingRepository,mapper);
        }
    }
}