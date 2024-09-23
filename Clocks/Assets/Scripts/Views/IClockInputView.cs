using System;

public interface IClockInputView
{
    event Action OnEditModeEnable;
    event Action OnEditModeQuit;
    event Action<int> OnHourChange;
}