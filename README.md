# Challenge .NET

## Introduction

*There is a chain of offices for rental distributed throughout the city.
Offices are rented by the hour individually.
A system is needed that manages reservations, optimizing the use of each office according to its capacity and available resources (whiteboard, projector, internet access, etc.).
Reservations are made back-to-back, there is no need to consider any time between the end of one reservation and the start of the next.*

## Required functionality

The *IOfficeRentalService* interface acts as the entry point for all operations.

**AddLocation**
Add a new location.

**GetLocations**
Get the list of premises.

**AddOffice**
Add an office to a premises.

**GetOffices**
Obtain all the offices of a location.

**BookOffice**
Reserve an office.

**GetBookings**
Obtain a list of reservations from an office.

**GetOfficeSuggestion**
Obtain a list of offices that match your specifications, sorted by convenience.
The suggestions must meet these conditions:

- allow the necessary capacity
- have all the requested resources
- it is preferable to reserve an office in the requested neighborhood but if there is none, other locations can be suggested
- it is preferable to keep the largest offices free
- it is preferable to keep offices free with more resources than are required

Suggestions must return all offices that meet the conditions.
The preferences must establish the order of the results, with the first being the one that most closely matches the query.

## Project

### NetChallenge/Abstractions

Contains the IBookingRepository, ILocationRepository, and IOfficeRepository data access abstractions.

### NetChallenge/Domain

Contains business classes.

- Location: it is a location that can contain several offices
- The name cannot be empty.
- The neighborhood cannot be empty.
- The name cannot be repeated.

- Office: it is an office within a premises.
  - Must belong to a valid location.
  - The name cannot be empty.
  - The name cannot be repeated within the same premises.
  - The maximum capacity must be greater than zero.
  - May have zero or more resources available.

- Booking: represents the reservation of an office for a specific date and time.
  - Must belong to a valid office.
  - It must have a duration greater than zero.
  - It should not overlap with other reservations from the same office.
  - The user who makes the reservation is required.

### NetChallenge/Dto/Input

Contains the DTOs with the input parameters for each functionality.

### NetChallenge/Dto/Output

Contains the output DTOs with which each functionality will respond.

## NetChallenge/Exceptions

Custom exceptions.

## NetChallenge/Infrastructure

**repository** implementation

## NetChallenge.Test

Unit tests to validate the implemented logic.

## Result

An implementation is expected that meets the requested functionality and passes all the tests.

What is expected to be modified:

- **Abstractions** There is no need to modify any of the interfaces.
- **Domain** Business entities must be implemented following Domain-Driven Design good practices.
- **Discount** It should not be modified.
- **Infrastructure** Repository abstractions must be implemented. The data is kept in memory.
- **Exceptions** Any necessary exceptions must be implemented.
- **OfficeRentalService** All functionality must be implemented. It is not necessary that all the logic is in this class, but be sure to keep its interface as an entry point.
- Tests: Existing tests should not be modified. If extra tests are required, another class can be added.

### Requirements

- All the tests must pass.
- The implementation must resolve the required functionality, not just what is in the tests.
- No need to add external references
- The code must be written in English.
- **Clean Code** and **SOLID** principles must be applied
- A robust business layer must be implemented following the principles of Domain-Driven Design.
- Correct exception handling must be done.
- The use of Linq is preferred and iterating collections to search for data is seen as bad practice.

### Will be taken into account

- Understanding of the problem raised
- Quality of the solution
- Detection of hidden needs
- Neatness of deliverables
- Clean Code
- SOLID principles
- Testability
- Extensibility
- Error handling
- Domain-Driven Design Concepts

    The subsequent technical interview will consist of the argument and review of the project presented
