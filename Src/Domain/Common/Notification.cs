using Domain.Common.Exceptions;

namespace Domain.Common;

public class Notification
{public Notification(string message, NotificationType notificationType)
    {
        if(string.IsNullOrEmpty(message))
        {
            throw new DomainException("Message cannot be null or empty");
        }

        if(notificationType != NotificationType.Warning && notificationType != NotificationType.Error)
        {
            throw new DomainException("Notification type must be Warning or Error");
        }

        Message = message;
        NotificationType = notificationType;
    }
    public string Message { get; private set; }
    public NotificationType NotificationType { get; private set; }
}

public enum NotificationType
{
    Warning = 1,
    Error = 2
}
