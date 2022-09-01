namespace Cppia.Std;

public class Date
{
    private readonly DateTime _time;

    public Date(int year, int month, int day, int hour, int min, int sec)
    {
        _time = new DateTime(year, month, day, hour, min, sec);
    }

    private Date(DateTime dateTime) => _time = dateTime;

    public double GetTime() => _time.TimeOfDay.TotalMilliseconds;
    public int GetHours() => _time.Hour;
    public int GetMinutes() => _time.Minute;
    public int GetSeconds() => _time.Second;
    public int GetFullYear() => _time.Year;
    public int GetMonth() => _time.Month;
    public int GetDate() => (int)_time.DayOfWeek;
    public int GetDay() => _time.Day;
    public int GetUTCHours() => _time.ToUniversalTime().Hour;
    public int GetUTCMinutes() => _time.ToUniversalTime().Minute;
    public int GetUTCSeconds() => _time.ToUniversalTime().Second;
    public int GetUTCFullYear() => _time.ToUniversalTime().Year;
    public int GetUTCDate() => (int)_time.ToUniversalTime().DayOfWeek;
    public int GetTimezoneOffset() => TimeZoneInfo.Local.GetUtcOffset(_time).Minutes;
    public override string ToString() => GetSeconds().ToString();
    public static Date Now() => new(DateTime.Now);
    public static Date FromTime(int miliseconds) => new(new DateTime(miliseconds * TimeSpan.TicksPerMillisecond));
    public static Date FromString(string s)
    {
		switch (s.Length) {
			case 8: // hh:mm:ss
				var k = s.Split(":");
                return new Date(0, 0, 0, int.Parse(k[0]), int.Parse(k[0]), int.Parse(k[0]));
            case 10: // YYYY-MM-DD
				var f = s.Split("-");
				return new Date(int.Parse(f[0]), int.Parse(f[1]), int.Parse(f[2]), 0, 0, 0);
			case 19: // YYYY-MM-DD hh:mm:ss
				var l = s.Split(" ");
				var y = l[0].Split("-");
				var t = l[1].Split(":");
				return new Date(int.Parse(y[0]), int.Parse(y[1]), int.Parse(y[2]), int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]));
			default:
				throw new InvalidDataException("Invalid date format : " + s);
		}
	}
}   