using System;
using System.Collections;

public interface IHandRotator
{
    public event Action<int> OnHandAngleChanged;
    public IEnumerator HandleMouseRotation();
}
