using UnityEngine;

public interface IClockHandUtility
{
    public void Rotate(Transform arrow, float angle);
    public float GetAngle(Transform arrow);
    public float CalculatedAngle(int units);
    public float CalculatedAngle(int units, int additionalUnits);
    public int GetTimeFromAngle(float angle, float degreesPerUnit, int unitsPerRevolution);
}
