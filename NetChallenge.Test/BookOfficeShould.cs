using System;
using System.Linq;
using NetChallenge.Test.Utils;
using Xunit;

namespace NetChallenge.Test
{
    public class BookOfficeShould : OfficeRentalServiceTest
    {
        public BookOfficeShould()
        {
            Service.AddLocation(AddLocationRequestMother.Default);
            Service.AddLocation(AddLocationRequestMother.Central);
            Service.AddOffice(AddOfficeRequestMother.Default);
            Service.AddOffice(AddOfficeRequestMother.Blue);
            Service.AddOffice(AddOfficeRequestMother.Red);
        }

        [Fact(Skip="Not implemented in TDD")]
        public void BookAnOffice()
        {
            var request = BookOfficeRequestMother.Default;

            Service.BookOffice(request);

            var bookings = Service.GetBookings(request.LocationName, request.OfficeName);
            Assert.Single(bookings);
            Assert.Contains(bookings, x => x.LocationName == request.LocationName &&
                                           x.OfficeName == request.OfficeName &&
                                           x.DateTime == request.DateTime &&
                                           x.Duration == request.Duration &&
                                           x.UserName == request.UserName);
        }

        [Fact(Skip="Not implemented in TDD")]
        public void BookAnOfficeBeforeAnotherBooking()
        {
            var date = BookOfficeRequestMother.Default.DateTime;
            var request1 = BookOfficeRequestMother.Default;
            var request2 = BookOfficeRequestMother.Default.WithDate(date.AddHours(-1)).WithDuration(TimeSpan.FromHours(1));

            Service.BookOffice(request1);
            Service.BookOffice(request2);

            Assert.Equal(2, BookingRepository.AsEnumerable().Count());
        }

        [Fact(Skip="Not implemented in TDD")]
        public void BookAnOfficeAfterAnotherBooking()
        {
            var date = BookOfficeRequestMother.Default.DateTime;
            var request1 = BookOfficeRequestMother.Default;
            var request2 = BookOfficeRequestMother.Default.WithDate(date.AddHours(1)).WithDuration(TimeSpan.FromHours(1));

            Service.BookOffice(request1);
            Service.BookOffice(request2);

            Assert.Equal(2, BookingRepository.AsEnumerable().Count());
        }

        [Fact(Skip="Not implemented in TDD")]
        public void BookAnOfficeWhenAnotherOneIsBooked()
        {
            var request1 = BookOfficeRequestMother.Default.WithOfficeName(AddOfficeRequestMother.Blue.Name);
            var request2 = BookOfficeRequestMother.Default.WithOfficeName(AddOfficeRequestMother.Red.Name);

            Service.BookOffice(request1);
            Service.BookOffice(request2);

            Assert.Equal(2, BookingRepository.AsEnumerable().Count());
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenLocationDoesNotExist()
        {
            var request = BookOfficeRequestMother.Default.WithLocationName("BAD LOCATION");

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenOfficeDoesNotExist()
        {
            var request = BookOfficeRequestMother.Default.WithOfficeName("BAD OFFICE");

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenDurationIsZero()
        {
            var request = BookOfficeRequestMother.Default.WithDuration(TimeSpan.Zero);

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenDurationIsNegative()
        {
            var request = BookOfficeRequestMother.Default.WithDuration(TimeSpan.FromHours(-1));

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenUserIsEmpty()
        {
            var request = BookOfficeRequestMother.Default.WithUserName("");

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenUserIsNull()
        {
            var request = BookOfficeRequestMother.Default.WithUserName(null);

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenOverlapingExactly()
        {
            var request1 = BookOfficeRequestMother.Default;
            var request2 = BookOfficeRequestMother.Default;

            Service.BookOffice(request1);

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request2));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenOverlapingInside()
        {
            var date = BookOfficeRequestMother.Default.DateTime;
            var request1 = BookOfficeRequestMother.Default.WithDuration(TimeSpan.FromHours(3));
            var request2 = BookOfficeRequestMother.Default.WithDate(date.AddHours(1)).WithDuration(TimeSpan.FromHours(1));

            Service.BookOffice(request1);

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request2));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenOverlapingOutside()
        {
            var date = BookOfficeRequestMother.Default.DateTime;
            var request1 = BookOfficeRequestMother.Default.WithDate(date.AddHours(1)).WithDuration(TimeSpan.FromHours(1));
            var request2 = BookOfficeRequestMother.Default.WithDuration(TimeSpan.FromHours(3));

            Service.BookOffice(request1);

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request2));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenOverlapingStart()
        {
            var date = BookOfficeRequestMother.Default.DateTime;
            var request1 = BookOfficeRequestMother.Default;
            var request2 = BookOfficeRequestMother.Default.WithDate(date.AddMinutes(-30)).WithDuration(TimeSpan.FromHours(1));

            Service.BookOffice(request1);

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request2));
        }

        [Fact(Skip="Not implemented in TDD")]
        public void ThrowWhenOverlapingEnd()
        {
            var date = BookOfficeRequestMother.Default.DateTime;
            var request1 = BookOfficeRequestMother.Default;
            var request2 = BookOfficeRequestMother.Default.WithDate(date.AddMinutes(30)).WithDuration(TimeSpan.FromHours(1));

            Service.BookOffice(request1);

            Assert.ThrowsAny<Exception>(() => Service.BookOffice(request2));
        }
    }
}