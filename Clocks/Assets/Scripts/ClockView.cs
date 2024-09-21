using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ClockView : MonoBehaviour
{
    [SerializeField] private Transform hourHand;
    [SerializeField] private Transform minuteHand;
    [SerializeField] private Transform secondHand;
    [SerializeField] private InputField hourInput;
    [SerializeField] private InputField minuteInput;
    [SerializeField] private Text timeText;

    private const int secondsPerRevolution = 60;
    private const int minutesPerRevolution = 60;
    private const int hoursPerRevolution = 12;

    public event Action<int, int> OnTimeChange;

    public void UpdateClockDisplay(DateTime currentTime)
    {
        float rotationSeconds = (360 / secondsPerRevolution) * currentTime.Second;
        float rotationMinutes = (360 / minutesPerRevolution) * currentTime.Minute;
        float rotationHours = (360 / hoursPerRevolution) * currentTime.Hour + (30f / minutesPerRevolution) * currentTime.Minute;

        hourHand.DORotate(new Vector3(0, 0, -rotationHours), 1f);
        minuteHand.DORotate(new Vector3(0, 0,-rotationMinutes), 1f);
        secondHand.DORotate(new Vector3(0, 0, -rotationSeconds), 0.5f);

        timeText.text = currentTime.ToString("HH:mm:ss");
    }

    public void OnSave()
    {
        int.TryParse(hourInput.text, out int  hour);
        int.TryParse(minuteInput.text, out int minute);

        if(IsValidTime(hour, minute))
            OnTimeChange?.Invoke(hour, minute);

        hourInput.text = string.Empty;
        minuteInput.text = string.Empty;
    }

    private bool IsValidTime(int hour, int minute)
    {
        return hour >= 0 && minute >= 0 && hour < 24 && minute < 60;
    }
}
