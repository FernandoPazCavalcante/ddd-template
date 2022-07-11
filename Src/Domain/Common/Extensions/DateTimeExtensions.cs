namespace Domain.Common.Extensions;

public static class DateTimeExtensions
{
    public static bool IsBetween(this DateTime dateTime, DateTime startDate, DateTime endDate)
    {
        return dateTime >= startDate && dateTime <= endDate;
    }
}
