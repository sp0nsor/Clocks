using DG.Tweening;
using UnityEngine;

public class ClockHandUtility : MonoBehaviour, IClockHandUtility
{
    public float CalculatedAngle(int units)
    {
        return (360f / ClockModel.UNITS_PER_REVOLUTION) * units;
    }

    public float CalculatedAngle(int hours, int minutes)
    {
        return (360f / ClockModel.HOURS_PER_REVOLUTION) * hours + (30f / ClockModel.UNITS_PER_REVOLUTION) * minutes;
    }

    public float GetAngle(Transform arrow)
    {
        Debug.Log(arrow.localRotation.eulerAngles.z);
        return arrow.localRotation.eulerAngles.z;
    }

    public int GetTimeFromAngle(float angle, float degreesPerUnit, int unitsPerRevolution)
    {
        Debug.Log(Mathf.FloorToInt(angle / degreesPerUnit) % unitsPerRevolution);
        return Mathf.FloorToInt(angle / degreesPerUnit) % unitsPerRevolution;
    }

    public void Rotate(Transform arrow, float angle)
    {
        arrow.DOLocalRotate(new Vector3(0, 0, angle), 0.5f);
    }
}
