namespace PassengerFlightApi.Models;

public class Passenger
{
    public int Id {get; set;}
    public string FirstName {get; set;} = string.Empty;
    public string LastName {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string PassportNumber {get; set;} = string.Empty;

}