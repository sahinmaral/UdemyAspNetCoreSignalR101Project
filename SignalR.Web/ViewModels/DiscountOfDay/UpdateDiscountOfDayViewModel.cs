namespace SignalR.Web.ViewModels.DiscountOfDay;

public class UpdateDiscountOfDayViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}