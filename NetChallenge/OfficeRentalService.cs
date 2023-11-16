using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Abstractions;
using NetChallenge.Data;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using NetChallenge.Infrastructure;

namespace NetChallenge
{
    public class OfficeRentalService
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly DbContext _context;

        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository, DbContext context, IMapper mapper)
        {
            _context = context;
            _locationRepository = new LocationRepository(_context as AppDbContext);
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public void AddLocation(AddLocationRequest request)
        {
                Location location = new Location();
                location.Neighborhood = request.Neighborhood;
                location.Name = request.Name;

                _locationRepository.Add(location);
                
            
        }

        public void AddOffice(AddOfficeRequest officeRequest)
        {
            Office office = new()
            {
                Name = officeRequest.Name,
                MaxCapacity = officeRequest.MaxCapacity,
            };
            office.Location = _locationRepository.GetOne(x => x.Name.Equals(officeRequest.LocationName));
            office.Facilities = this.GetFacilities(officeRequest.Facilities);
            _officeRepository.Add(office);
        }

        private ICollection<Facility> GetFacilities(IEnumerable<string> officeRequestFacilities)
        {
            List<Facility> facilitiesList = new();
            foreach (var officeRequestFacility in officeRequestFacilities)
            {
                Facility facility = new() { Name = officeRequestFacility };
                facilitiesList.Add(facility);
            }
            return facilitiesList;
        }

        public void BookOffice(BookOfficeRequest bookOfficeRequest)
        {
            ValidateBookingOfficeWhenAnotherOneIsBooked(bookOfficeRequest);

            var user = new UserRepository().GetOne(x => x.Name.Trim().Equals(bookOfficeRequest.UserName.Trim()));
            var office = _officeRepository.GetOne(x => x.Name.Trim().Equals(bookOfficeRequest.OfficeName.Trim()));

            _bookingRepository.Add(new()
            {
                DateTime = bookOfficeRequest.DateTime,
                Duration = bookOfficeRequest.Duration,
                User = user,

            });
        }

        private void ValidateBookingOfficeWhenAnotherOneIsBooked(BookOfficeRequest bookOfficeRequest)
        {
            //TODO add a repo method to get just the dates
            var bookings = _bookingRepository.GetAll();
            var bookOfficeRequestDateTimeEnd = bookOfficeRequest.DateTime.Add(bookOfficeRequest.Duration);

            var dateTimeStartItems = new SortedSet<DateTime>(bookings.Select(x => x.DateTime));
            DateTime officeBusySince = dateTimeStartItems
                .GetViewBetween(bookOfficeRequestDateTimeEnd, DateTime.MaxValue)
                .FirstOrDefault();
            bool conditionsForNextEventStartOverlap =
                officeBusySince != default
                && officeBusySince < bookOfficeRequestDateTimeEnd;

            TimeSpan suggestedDuration = officeBusySince - bookOfficeRequest.DateTime;

            if (conditionsForNextEventStartOverlap) throw new Exception($"There's an event already starting before {bookOfficeRequestDateTimeEnd} . Suggested duration : {suggestedDuration}");
            //TODO persist the DateTimeEnd to avoid this calculation. The DateEnd is more frecuently used than the Duration
            var dateTimeEndItems = new SortedSet<DateTime>(bookings.Select(x => x.DateTime.Add(x.Duration)));
            DateTime officeFreeSince = dateTimeEndItems
              .GetViewBetween(DateTime.MinValue, bookOfficeRequest.DateTime)
              .FirstOrDefault();
            bool conditionsForPreviusEventEndOverlap =
              officeFreeSince != default && officeFreeSince > bookOfficeRequest.DateTime;
            if (conditionsForPreviusEventEndOverlap) throw new Exception($"There's an eventalready ending after {bookOfficeRequest.DateTime}. Suggested starting since: {officeFreeSince}");

            //TODO this is not used, but it implies that 3 unit test must be done with failing assertions; and 3 with success assertion 
            //bool conditionsForEventOverlap = conditionsForNextEventStartOverlap || conditionsForPreviusEventEndOverlap;//TODO delete after adding tests
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocationDto> GetLocations() => _locationRepository
            .GetAllDeprecated()
            //.AsQueryable()//TODO try this to delay materialization and run test again
            .ToList()
            .Select(x => new LocationDto
            {
                Name = x.Name,
                Neighborhood = x.Neighborhood,
            });


        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}