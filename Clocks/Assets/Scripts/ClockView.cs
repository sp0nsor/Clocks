using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ClockView : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;
    public Text timeText;

    public void UpdateClockDisplay(DateTime currentTime)
    {
        float rotationSeconds = (360.0f / 60.0f) * currentTime.Second;
        float rotationMinutes = (360.0f / 60.0f) * currentTime.Minute;
        float rotationHours = ((360.0f / 12.0f) * currentTime.Hour) + ((360.0f / (60.0f * 12.0f)) * currentTime.Minute);

        hourHand.DORotate(new Vector3(0, 0, -rotationHours), 1f);
        minuteHand.DORotate(new Vector3(0, 0,-rotationMinutes), 1f);
        secondHand.DORotate(new Vector3(0, 0, -rotationSeconds), 0.5f);

        timeText.text = currentTime.ToString("HH:mm:ss");
    }
}
