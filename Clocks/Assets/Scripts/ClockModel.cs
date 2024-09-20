using System;
using System.Threading.Tasks;

public class ClockModel
{
    private ITimeService timeService;

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
}
