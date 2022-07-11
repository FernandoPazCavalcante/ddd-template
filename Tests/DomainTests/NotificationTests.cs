using System;
using Domain.Common;
using Domain.Common.Exceptions;
using Xunit;

namespace Tests.DomainTests;

public class NotificationTests
{
    [Fact]
    public void CreateNotification_WhereMessageIsNullOrEmpty_ShouldThrowsDomainException()
    {
        // Given
        Notification notification = null;

        // When
        Action createNotification = () => notification = new Notification(string.Empty, NotificationType.Warning);

        // Then
        Assert.Throws<DomainException>(createNotification);
    }

    [Fact]
    public void CreateNotification_WhereNotificationTypeDifferentThanWarningOrError_ShouldThrowDomainException()
    {
        // Given
        Notification notification = null;

        // When
        Action createNotification = () => notification = new Notification("Test", (NotificationType)3);

        // Then
        Assert.Throws<DomainException>(createNotification);
    }
}
