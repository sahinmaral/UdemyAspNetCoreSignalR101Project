namespace SignalR.Web.ViewModels.Notification;

public class CreateNotificationViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}