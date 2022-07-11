using System.Collections.ObjectModel;
using Domain.Common;
using Domain.Common.Exceptions;
using Domain.Interfaces;

namespace Domain.Business.Notifications;

public class NotificationServices : INotification
{
    private List<Notification> notifications;

    private ReadOnlyCollection<Notification> Notifications
    {
        get
        {
            return notifications.AsReadOnly();
        }
    }

    public NotificationServices()
    {
        notifications = new List<Notification>();
    }

    public async Task<IEnumerable<Domain.Common.Notification>> GetAll()
    {
        return await Task.Run(() => Notifications);
    }

    public async Task<IEnumerable<Domain.Common.Notification>> GetErrors()
    {
        return await Task.Run(() => GetErrorNotifications());
    }

    public async Task Handle(Domain.Common.Notification notification)
    {
        if (notification == null)
            throw new DomainException("Notification cannot be null");

        if (Notifications.Any(notification => notification.Message == notification.Message
                                    && notification.NotificationType == notification.NotificationType))
            return;

        await Task.Run(() => notifications.Add(notification));
    }

    public Task HandleError(string errorMessage)
    {
        return Handle(new Notification(errorMessage, NotificationType.Error));
    }

    public async Task<bool> HasErrors()
    {
        return await Task.Run(() => notifications.Any(n => n.NotificationType == NotificationType.Error));
    }

    private IEnumerable<Notification>? GetErrorNotifications()
    {
        return Notifications.Where(nt => nt.NotificationType == NotificationType.Error);
    }
}
