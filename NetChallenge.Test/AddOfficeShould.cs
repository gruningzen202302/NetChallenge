using System;
using System.Linq;
using NetChallenge.Test.Utils;
using Xunit;

namespace NetChallenge.Test
{
    public class AddOfficeShould : OfficeRentalServiceTest
    {
        public AddOfficeShould()
        {
            Service.AddLocation(AddLocationRequestMother.Default);
            Service.AddLocation(AddLocationRequestMother.Central);
            Service.AddLocation(AddLocationRequestMother.Palermo);
        }

        [Fact]
        //[Fact(Skip="Not implemented in TDD")]
        public void AddOffice()
        {
            var request = AddOfficeRequestMother.Default;

            Service.AddOffice(request);

            var office = Service.GetOffices(request.LocationName).Single();
            Assert.Equal(request.LocationName, office.LocationName);
            Assert.Equal(request.Name, office.Name);
            Assert.Equal(request.MaxCapacity, office.MaxCapacity);
            Assert.Equal(request.Facilities.Count(), office.Facilities.Length);
            Assert.All(request.Facilities, x => Assert.Contains(x, office.Facilities));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void AddOfficeWithNoResources()
        {
            var request = AddOfficeRequestMother.Default.WithAvailableResources(Array.Empty<string>());

            Service.AddOffice(request);

            var office = Service.GetOffices(request.LocationName).Single();
            Assert.Equal(request.LocationName, office.LocationName);
            Assert.Equal(request.Name, office.Name);
            Assert.Equal(request.MaxCapacity, office.MaxCapacity);
            Assert.Equal(request.Facilities.Count(), office.Facilities.Length);
            Assert.Empty(office.Facilities);
        }

        [Fact(Skip="Not implemented in TDD")]
        public void AddMultipleOfficesOnTheSameLocation()
        {
            var locationName = AddLocationRequestMother.Central.Name;
            var requestBlue = AddOfficeRequestMother.Blue.WithLocationName(locationName);
            var requestRed = AddOfficeRequestMother.Red.WithLocationName(locationName);

            Service.AddOffice(requestBlue);
            Service.AddOffice(requestRed);

            var offices = Service.GetOffices(locationName);
            Assert.Equal(2, offices.Count());
            Assert.Contains(offices, x => x.LocationName == locationName && x.Name == requestBlue.Name && x.MaxCapacity == requestBlue.MaxCapacity);
            Assert.Contains(offices, x => x.LocationName == locationName && x.Name == requestRed.Name && x.MaxCapacity == requestRed.MaxCapacity);
        }

        [Fact(Skip="Not implemented in TDD")]
        public void AddMultipleOfficesWithTheSameNameInDiferentLocations()
        {
            var locationNameCentral = AddLocationRequestMother.Central.Name;
            var locationNamePalermo = AddLocationRequestMother.Palermo.Name;
            var requestBlue = AddOfficeRequestMother.Blue.WithLocationName(locationNameCentral);
            var requestRed = AddOfficeRequestMother.Blue.WithLocationName(locationNamePalermo);

            Service.AddOffice(requestBlue);
            Service.AddOffice(requestRed);

            var officeCentral = Service.GetOffices(locationNameCentral).Single();
            Assert.Equal(locationNameCentral, officeCentral.LocationName);
            Assert.Equal(requestBlue.Name, officeCentral.Name);

            var officePalermo = Service.GetOffices(locationNamePalermo).Single();
            Assert.Equal(locationNamePalermo, officePalermo.LocationName);
            Assert.Equal(requestRed.Name, officePalermo.Name);
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenLocationDoesNotExist()
        {
            var request = AddOfficeRequestMother.Default.WithLocationName("BAD LOCATION");

            Assert.ThrowsAny<Exception>(() => { Service.AddOffice(request); });
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenOfficeNameIsEmpty()
        {
            var request = AddOfficeRequestMother.Default.WithName("");

            Assert.ThrowsAny<Exception>(() => { Service.AddOffice(request); });
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenOfficeNameIsNull()
        {
            var request = AddOfficeRequestMother.Default.WithName(null);

            Assert.ThrowsAny<Exception>(() => { Service.AddOffice(request); });
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenOfficeNameAlreadyExistsOnLocation()
        {
            var locationName = AddLocationRequestMother.Central.Name;
            var request1 = AddOfficeRequestMother.Blue.WithLocationName(locationName).WithName("Same Name");
            var request2 = AddOfficeRequestMother.Red.WithLocationName(locationName).WithName("Same Name");
            Service.AddOffice(request1);

            Assert.ThrowsAny<Exception>(() => { Service.AddOffice(request2); });
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenMaxCapacityIsZero()
        {
            var request = AddOfficeRequestMother.Default.WithMaxCapacity(0);

            Assert.ThrowsAny<Exception>(() => { Service.AddOffice(request); });
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenMaxCapacityIsNegative()
        {
            var request = AddOfficeRequestMother.Default.WithMaxCapacity(-1);

            Assert.ThrowsAny<Exception>(() => { Service.AddOffice(request); });
        }
    }
}