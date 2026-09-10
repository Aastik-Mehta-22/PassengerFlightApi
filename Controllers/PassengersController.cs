using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PassengerFlightApi.Models;

namespace PassengerFlightApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PassengersController : ControllerBase
{
    private static readonly List<Passenger> Passengers = new()
    {
        new Passenger
        {
            Id=1,
            FirstName="John",
            LastName="Doe",
            Email="john@example.com",
            PassportNumber="P1234567"
        },
        new Passenger
        {
            Id=2,
            FirstName="leo",
            LastName="wall",
            Email="leo@example.com",
            PassportNumber="P1234568"
        }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Passenger>> GetPassengers()
    {
        return Ok(Passengers);
    }

    [HttpGet("{id}")]
    public ActionResult<Passenger> GetPassenger(int id)
    {
        var passenger = Passengers.FirstOrDefault(p => p.Id == id);

        if (passenger is null)
        {
            return NotFound();
        }

        return Ok(passenger);
    }

    [HttpPost]
    public ActionResult<Passenger> CreatePassenger(Passenger passenger)
    {
        passenger.Id = Passengers.Count + 1;

        Passengers.Add(passenger);

        return CreatedAtAction(
            nameof(GetPassenger),
            new { id = passenger.Id },
            passenger);
    }

    [HttpPut("{id}")]
    public ActionResult<Passenger> UpdatePassenger(int id, Passenger updatedPassenger)
    {
        var passenger = Passengers.FirstOrDefault(p => p.Id == id);

        if (passenger is null)
        {
            return NotFound();
        }

        passenger.FirstName = updatedPassenger.FirstName;
        passenger.LastName = updatedPassenger.LastName;
        passenger.Email = updatedPassenger.Email;
        passenger.PassportNumber = updatedPassenger.PassportNumber;

        return Ok(passenger);
    }
}