using System;
using UnityEngine;
using UnityEngine.UI;

public class ClockDisplayView : MonoBehaviour, IClockDisplayView
{
    [SerializeField] private Transform hourHandTransform;
    [SerializeField] private Transform minuteHandTransform;
    [SerializeField] private Transform secondHandTransform;
    [SerializeField] private Text timeText;

    private IClockHandUtility clockUtility;

    private void Awake()
    {
        clockUtility = GetComponentInChildren<IClockHandUtility>();
    }

    public void UpdateClockDisplay(DateTime currentTime)
    {
        float rotationSeconds = clockUtility.CalculatedAngle(currentTime.Second);
        float rotationMinutes = clockUtility.CalculatedAngle(currentTime.Minute);
        float rotationHours = clockUtility.CalculatedAngle(currentTime.Hour, currentTime.Minute);

        clockUtility.Rotate(secondHandTransform, rotationSeconds);
        clockUtility.Rotate(minuteHandTransform, rotationMinutes);
        clockUtility.Rotate(hourHandTransform, rotationHours);

        timeText.text = currentTime.ToString("HH:mm:ss");
    }
}
