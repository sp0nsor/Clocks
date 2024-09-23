using UnityEngine;
using System.Collections;
using System;

public class HourHandRotator : MonoBehaviour, IHandRotator
{
    [SerializeField] private Transform rotationCenter;
    private IClockHandUtility clockUtility;
    
    public event Action<int> OnHandAngleChanged;

    private void Awake()
    {
        clockUtility = GetComponentInParent<IClockHandUtility>();
    }

    private void OnMouseDown()
    {
        StartCoroutine(HandleMouseRotation());
    }

    public IEnumerator HandleMouseRotation()
    {
        while (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition; 
            mousePosition.z = Camera.main.WorldToScreenPoint(rotationCenter.position).z;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 directionToMouse = mouseWorldPosition - rotationCenter.position;

            float angle = Vector2.SignedAngle(directionToMouse, transform.up);

            transform.localRotation = Quaternion.Euler(0, 0, transform.localEulerAngles.z + angle);

            yield return null;
        }

        int hours = clockUtility.GetTimeFromAngle(clockUtility.GetAngle(transform),
            ClockModel.HOURS_DEGREES_PER_UNIT, ClockModel.HOURS_PER_REVOLUTION);
        OnHandAngleChanged?.Invoke(hours);
    }
}
