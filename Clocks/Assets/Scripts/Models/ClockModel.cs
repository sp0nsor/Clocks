using System;
using System.Threading.Tasks;

public class ClockModel
{
    private ITimeService timeService;

    public const int HOURS_PER_REVOLUTION = 12;
    public const int UNITS_PER_REVOLUTION = 60;
    public const int HOURS_DEGREES_PER_UNIT = 30;
    public DateTime CurrentTime { get; private set; }

    public ClockModel(ITimeService timeService) 
    {
        this.timeService = timeService;
    }

    public void UpdateTime()
    {
        CurrentTime = CurrentTime.AddSeconds(1f);
    }

    public async Task SysncTimeWithNetwork()
    {
        CurrentTime = await timeService.GetNetworkTime();
    }

    public void ChangeHour(int hour)
    {
        CurrentTime = new DateTime(CurrentTime.Year, CurrentTime.Month, CurrentTime.Day, hour, CurrentTime.Minute, CurrentTime.Second);
    }
}
