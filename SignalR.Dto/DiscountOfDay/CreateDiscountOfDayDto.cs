namespace SignalR.Dto.DiscountOfDay;

public class CreateDiscountOfDayDto
{
    public string Title { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}