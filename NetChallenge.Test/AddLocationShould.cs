using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;
using Moq;
using NetChallenge.Data;
using NetChallenge.Domain;
using NetChallenge.Infrastructure;
using NetChallenge.Test.Utils;
using Xunit;

namespace NetChallenge.Test
{
    public class AddLocationShould : OfficeRentalServiceTest
    {
        [Fact]
        public void AddLocation()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Location>>();
            var mockContext = new Mock<AppDbContext>();

            // mockContext
            // .Setup(mockContext =>
            //     mockContext.Locations)
            // .Returns(
            //     mockSet.Object
            // //mockContext.Locations()
            // )
            // ;

            // mockContext.Object.Locations.Add(new Location
            // {
            //     Name = "The Name",
            //     Neighborhood = "The nbg",
            // });


            // Act
            //var repository = new LocationRepository(mockContext.Object);
            //repository.Add(new Location());
            //var repository = new LocationRepository();

            // Assert
            //mockSet.Verify(m => m.Add(It.IsAny<Location>()), Times.Once());

            var request = AddLocationRequestMother.Default;

            Service.AddLocation(request);

            var location = Service.GetLocations().Single();
            Assert.Equal(request.Name, location.Name);
            Assert.Equal(request.Neighborhood, location.Neighborhood);
        }

        [Fact(Skip = "not implemented for TDD ")]
        public void AddMultipleLocations()
        {
            var requestCentral = AddLocationRequestMother.Central;
            var requestAlmagro = AddLocationRequestMother.Almagro;
            var requestPalermo = AddLocationRequestMother.Palermo;

            Service.AddLocation(requestCentral);
            Service.AddLocation(requestAlmagro);
            Service.AddLocation(requestPalermo);

            var locations = Service.GetLocations();
            Assert.Equal(3, locations.Count());
            Assert.Contains(locations, x => x.Name == requestCentral.Name && x.Neighborhood == requestCentral.Neighborhood);
            Assert.Contains(locations, x => x.Name == requestAlmagro.Name && x.Neighborhood == requestAlmagro.Neighborhood);
            Assert.Contains(locations, x => x.Name == requestPalermo.Name && x.Neighborhood == requestPalermo.Neighborhood);
        }

        [Fact(Skip = "not implemented for TDD ")]
        public void ThrowWhenLocationNameIsEmpty()
        {
            var request = AddLocationRequestMother.Default.WithName("");

            Assert.ThrowsAny<Exception>(() => { Service.AddLocation(request); });
        }

        [Fact(Skip = "not implemented for TDD ")]
        public void ThrowWhenLocationNameIsNull()
        {
            var request = AddLocationRequestMother.Default.WithName(null);

            Assert.ThrowsAny<Exception>(() => { Service.AddLocation(request); });
        }

        [Fact(Skip = "not implemented for TDD ")]
        public void ThrowWhenLocationNeighborhoodIsEmpty()
        {
            var request = AddLocationRequestMother.Default.WithNeighborhood("");

            Assert.ThrowsAny<Exception>(() => { Service.AddLocation(request); });
        }

        [Fact(Skip = "not implemented for TDD ")]
        public void ThrowWhenLocationNeighborhoodIsNull()
        {
            var request = AddLocationRequestMother.Default.WithNeighborhood(null);

            Assert.ThrowsAny<Exception>(() => { Service.AddLocation(request); });
        }

        
        [Fact(Skip = "not implemented for TDD ")]
        public void ThrowWhenLocationNameAlreadyExists()
        {
            var request1 = AddLocationRequestMother.Central;
            var request2 = AddLocationRequestMother.Default.WithName(request1.Name);
            Service.AddLocation(request1);

            Assert.ThrowsAny<Exception>(() =>
            {
                Service.AddLocation(request2);
            });
        }
    }
}