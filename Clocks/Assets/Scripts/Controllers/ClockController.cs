using UnityEngine;

public class ClockController : MonoBehaviour
{
    private ClockModel clockModel;
    private IClockDisplayView clockDisplayView;
    private IClockInputView clockInputView;
    private IHandRotator handRotator;

    private void Start()
    {
        clockDisplayView = GetComponent<IClockDisplayView>();
        clockInputView = GetComponent<IClockInputView>();
        handRotator = GetComponentInChildren<IHandRotator>();

        clockModel = new ClockModel(new TimeService());

        clockInputView.OnEditModeEnable += StopClockUpdates;
        clockInputView.OnEditModeQuit += StartClockUpdates;

        clockInputView.OnHourChange += ChangeTime;
        handRotator.OnHandAngleChanged += ChangeTime;

        InitializeClock();
    }

    private async void InitializeClock()
    {
        await clockModel.SysncTimeWithNetwork();
        clockDisplayView.UpdateClockDisplay(clockModel.CurrentTime);
        StartClockUpdates();
    }

    private void ChangeTime(int hour)
    {
        clockModel.ChangeHour(hour);
        clockDisplayView.UpdateClockDisplay(clockModel.CurrentTime);
    }

    private void Tick()
    {
        clockModel.UpdateTime();
        clockDisplayView.UpdateClockDisplay(clockModel.CurrentTime);
    }

    private void StartClockUpdates()
    {
        InvokeRepeating(nameof(Tick), 1f, 1f);
        InvokeRepeating(nameof(SyncClock), 3600f, 3600f);
    }

    private void StopClockUpdates()
    {
        CancelInvoke(nameof(Tick));
        CancelInvoke(nameof(SyncClock));
    }

    private async void SyncClock()
    {
        await clockModel.SysncTimeWithNetwork();
        clockDisplayView.UpdateClockDisplay(clockModel.CurrentTime);
    }

    private void OnDestroy()
    {
        clockInputView.OnHourChange -= ChangeTime;
        clockInputView.OnEditModeEnable -= StopClockUpdates;
        clockInputView.OnEditModeQuit -= StartClockUpdates;
        handRotator.OnHandAngleChanged -= ChangeTime;
    }
}
