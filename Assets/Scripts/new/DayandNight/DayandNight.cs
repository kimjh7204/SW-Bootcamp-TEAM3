using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float daySeconds = 60f;
    public float rotationSpeed = 10f; 

    private float currentRotation = 50f;

    private void Update()
    {
        UpdateDayNightCycle();
    }

    private void UpdateDayNightCycle()
    {
        float anglePerSecond = 360f / daySeconds;
        float rotationAmount = anglePerSecond * Time.deltaTime;
        
        currentRotation += rotationAmount;
        if (currentRotation >= 360f)
        {
            currentRotation -= 360f;
        }
        transform.rotation = Quaternion.Euler(currentRotation, -30f, 0f);
    }
}
