using System;
using System.Collections.Generic;
using System.Linq;
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
            var offices = _officeRepository.GetAll();
            throw new NotImplementedException();
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocationDto> GetLocations() => _locationRepository
            .GetAll()
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