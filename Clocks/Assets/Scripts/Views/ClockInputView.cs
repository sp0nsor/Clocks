using System;
using UnityEngine;
using UnityEngine.UI;

public class ClockInputView : MonoBehaviour, IClockInputView
{
    [SerializeField] private InputField hourInput;
    public event Action<int> OnHourChange;
    public event Action OnEditModeEnable;
    public event Action OnEditModeQuit;

    public void OnSave()
    {
        OnEditModeQuit?.Invoke();
        if (hourInput.text == string.Empty)
            return;

        if (int.TryParse(hourInput.text, out int hour) && IsValidHour(hour))
            OnHourChange?.Invoke(hour);

        hourInput.text = string.Empty;
    }

    public void OnEditButtonClick()
    {
        OnEditModeEnable?.Invoke();
    }

    private bool IsValidHour(int hour)
    {
        return hour >= 0 && hour < 24;
    }
}
