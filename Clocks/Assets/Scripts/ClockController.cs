using UnityEngine;

public class ClockController : MonoBehaviour
{
    private ClockModel clockModel;
    private ClockView clockView;

    private void Start()
    {
        clockView = GetComponent<ClockView>();
        clockModel = new ClockModel(new TimeService()); // не совсем корректно конечно 

        InitializeClock();
    }

    private async void InitializeClock()
    {
        await clockModel.SysncTimeWithNetwork();
        clockView.UpdateClockDisplay(clockModel.CurrentTime);

        InvokeRepeating(nameof(Tick), 1f, 1f);
        InvokeRepeating(nameof(SyncClock), 3600f, 3600f);
    }

    private void Tick()
    {
        clockModel.UpdateTime();
        clockView.UpdateClockDisplay(clockModel.CurrentTime);
    }

    private async void SyncClock()
    {
        await clockModel.SysncTimeWithNetwork();
        clockView.UpdateClockDisplay(clockModel.CurrentTime);
    }
}
