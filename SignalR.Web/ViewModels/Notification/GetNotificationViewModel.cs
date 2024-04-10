namespace SignalR.Web.ViewModels.Notification;

public class GetNotificationViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}