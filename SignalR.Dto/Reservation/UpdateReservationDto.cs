namespace SignalR.Dto.Reservation;

public class UpdateReservationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int PersonAmount { get; set; }
    public DateTime Date { get; set; }
}