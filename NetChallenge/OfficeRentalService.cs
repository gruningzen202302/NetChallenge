using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly DbContext _context;

        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
        }

        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository, DbContext context )
        {
            _context = context;
            _locationRepository = new LocationRepository(_context as AppDbContext);
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
        }
        public void AddLocation(AddLocationRequest request)
        {
                Location location = new Location();
                location.Neighborhood = request.Neighborhood;
                location.Name = request.Name;

                _locationRepository.Add(location);
                
            
        }

        public void AddOffice(AddOfficeRequest request)
        {
            throw new NotImplementedException();
        }

        public void BookOffice(BookOfficeRequest request)
        {
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