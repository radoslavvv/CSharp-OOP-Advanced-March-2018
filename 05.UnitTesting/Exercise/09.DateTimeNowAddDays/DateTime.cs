using System;
using System.Globalization;

public class CustomDateTime
{
    private DateTime date;

    public CustomDateTime()
    {

    }
    
    public CustomDateTime(DateTime date)
    {
        this.Date = date;
    }

    public DateTime Date { get; private set; }
    public DateTime Now() => DateTime.Now.Date;

    public DateTime AddDays(DateTime date, int daysCount) => date.AddDays(daysCount);

    public TimeSpan SubstractDays(DateTime date, int daysCount) => date.Subtract(DateTime.Parse($"{daysCount}", CultureInfo.InvariantCulture));
}

