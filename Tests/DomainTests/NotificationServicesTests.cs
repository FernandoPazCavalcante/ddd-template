using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Business.Notifications;
using Domain.Common;
using Domain.Common.Exceptions;
using Xunit;

namespace Tests.DomainTests;

public class NotificationServicesTests
{
    [Fact]
    public void Handle_WhereNotificationIsNull_ShouldThrowsDomainException()
    {
        // Given
        Notification notification = null;
        var notificationServices = new NotificationServices();

        // When
        Func<Task> handleNotification = () => notificationServices.Handle(notification);
    
        // Then
        Assert.ThrowsAsync<DomainException>(handleNotification);
    }

    [Fact]
    public void Handle_WhereNotificationAlreadyHandled_ShouldNotAddToNotifications()
    {
        // Given
        Notification notification = new Notification("Test", NotificationType.Warning);
        Notification notification2 = new Notification("Test", NotificationType.Warning);
        var notificationServices = new NotificationServices();
    
        // When
        notificationServices.Handle(notification).Wait();
        notificationServices.Handle(notification2).Wait();

        // Then
        Assert.Equal(1, notificationServices.GetAll().Result.Count());
    }

    [Fact]
    public void Handle_WhereNotificationIsValid_ShouldAddToNotifications()
    {
        // Given
        Notification notification = new Notification("Test", NotificationType.Warning);
        var notificationServices = new NotificationServices();
    
        // When
        notificationServices.Handle(notification).Wait();

        // Then
        Assert.Equal(1, notificationServices.GetAll().Result.Count());
    }

    [Fact]
    public void HandleError_WhereErrorMessageIsNullOrEmpty_ShouldThrowsDomainException()
    {
        // Given
        string errorMessage = null;
        var notificationServices = new NotificationServices();
    
        // When
        Action handleError = () => notificationServices.HandleError(errorMessage);
    
        // Then
        Assert.Throws<DomainException>(handleError);
    }

    [Fact]
    public void HandleError_WhereErrorMessageIsValid_ShouldAddToNotifications()
    {
        // Given
        string errorMessage = "Test";
        var notificationServices = new NotificationServices();
    
        // When
        notificationServices.HandleError(errorMessage).Wait();

        // Then
        Assert.Equal(1, notificationServices.GetAll().Result.Count());
    }
}
