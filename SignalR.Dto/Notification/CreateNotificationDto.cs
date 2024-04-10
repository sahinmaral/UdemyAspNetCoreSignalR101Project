namespace SignalR.Dto.Notification;

public class CreateNotificationDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}