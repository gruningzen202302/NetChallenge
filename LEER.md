# Challenge .NET

## Introduccion

*Se dispone de una cadena de locales de oficinas distribuidos por toda la ciudad.
Las oficinas se alquilan por hora individualmente.
Se necesita un sistema que administre las reservas optimizando el uso de cada oficina segun su capacidad y recursos disponibles (pizarra, proyector, acceso a internet, etc.).
Las reservas se hacen back-to-back, no hace falta considerar ningun tiempo entre el fin de una reserva y el inicio de la siguiente.*

## Funcionalidad requerida

La interface *IOfficeRentalService* actua como punto de entrada para todas las operaciones.

**AddLocation**
Agregar un local nuevo.

**GetLocations**
Obtener el listado de locales.

**AddOffice**
Agregar una oficina a un local.

**GetOffices**
Obtener todas las oficinas de un local.

**BookOffice**
Reservar una oficina.

**GetBookings**
Obtener un listado de reservas de una oficina.

**GetOfficeSuggestion**
Obtener un listado de oficinas que coincidan con las especificaciones, ordenados por conveniencia.
Las sugerencias tiene que cumplir estas condiciones:

- permitir la capacidad necesaria
- tener todos los recursos solicitados
- es preferible reservar una oficina en el barrio solicitado pero si no hay ninguna se pueden sugerir otros locales
- es preferible mantener libres las oficinas mas grandes
- es preferible mantener libres las oficinas con mas recursos de los que se requieren

Las sugerencias deben devolver todas las oficinas que cumplan las condiciones.
Las preferencias deben establecer el orden de los resultado, siendo la primera la que mayor coincidencia tiene con la consulta.

## Proyecto

### NetChallenge/Abstractions

Contiene las abstracciones de accesso a datos IBookingRepository, ILocationRepository y IOfficeRepository.

### NetChallenge/Domain

Contiene las clases de negocio.

- Location: es un local que puede contener varias oficinas
  - El nombre no puede estar vacio.
  - El barrio no puede estar vacio.
  - El nombre no puede repetirse.

- Office: es una oficina dentro de un local.
  - Debe pertenecer a un local valido.
  - El nombre no puede estar vacio.
  - El nombre no puede repetirse dentro del mismo local.
  - La capacidad maxima debe ser mayor a cero.
  - Puede tener cero o mas recursos disponibles.

- Booking: representa la reserva de una oficina para una fecha y un horario determinado.
  - Debe pertenecer a una oficina valida.
  - Debe tener una duracion mayor a cero.
  - No se debe superponer con otras reservas de la misma oficina.
  - El usuario que hace la reserva es obligatorio.

### NetChallenge/Dto/Input

Contiene los DTO con los parametros de entrada para cada funcionalidad.

### NetChallenge/Dto/Output

Contiene los DTO de salida con los que se va a responder cada funcionalidad.

## NetChallenge/Exceptions

Excepciones personalizadas.

## NetChallenge/Infrastructure

Implementacion de los **repository**

## NetChallenge.Test

Tests unitarios para validar la logica implementada.

## Resultado

Se espera una implementacion que cumpla con la funcionalidad solicitada y pase todos los tests.

Que se espera que se modifique:

- **Abstractions** No face falta modificar ninguna de las interfaces.
- **Domain** Se deben implementar las entidades de negocio siguiendo las buenas practicas de Domain-Driven Design.
- **Dto** No se debe modificar.
- **Infrastructure** Se deben implementar las abstracciones de los repository. Los datos se mantienen en memoria.
- **Excepciones** Se deben implementar las excepciones que hagan falta.
- **OfficeRentalService** Se debe implementar toda la funcionalidad. No es necesario que toda la logica esta en esta clase, pero se que se mantenga su interface como punto de entrada.
- Tests: No se deben modificar los tests existentes. Si se requieren tests extra se puede agregar otra clase.

### Requerimientos

- Deben pasar todos los tests.
- La implementacion debe resolver la funcionalidad requerida, no solamente la que esta en los tests.
- No es necesario agregar referencias externas
- El codigo debe escribirse en ingles.
- Se deben aplicar los principios de **Clean Code** y **SOLID**
- Se debe implementar una capa de negocio robusta siguiendo los principios del Domain-Driven Design.
- Se debe hacer un correcto manejo de excepciones.
- Se prefiere el uso de Linq y esta visto como una mala practica la iteracion de colecciones para buscar datos.

### Se tendra en cuenta

- Comprension de la problematica planteada
- Calidad de la solucion
- Deteccion de necesidades ocultas
- Prolijidad de los entregables
- Clean Code
- Principios SOLID
- Testeablidad
- Extensibilidad
- Manejo de errores
- Conceptos de Domain-Driven Design

La entrevista tecnica posterior consistira en la argumentacion y revision del proyecto presentado
