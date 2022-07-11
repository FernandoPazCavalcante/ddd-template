using Domain.Common;

namespace Domain.Interfaces;

public interface INotification
{
    Task Handle(Notification notification);
    Task HandleError(string errorMessage);
    Task<IEnumerable<Notification>> GetAll();
    Task<IEnumerable<Notification>> GetErrors();
    Task<bool> HasErrors();
}
