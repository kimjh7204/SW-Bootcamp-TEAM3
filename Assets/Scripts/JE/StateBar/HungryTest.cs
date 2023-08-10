using UnityEngine;
using UnityEngine.UI;

public class HungryTest : MonoBehaviour
{
    public Slider hungerSlider;
    public Image hungerImage;
    public float minValue = 0f;
    public float maxValue = 1f;
    public float hungerDecreaseRate = 0.1f;
    public float hungerIncreaseRate = 0.05f; // 감소 증가는 테스트 하기 위해 임시로 해놓은거임 나중에 변경하면 될 듯함

    private bool isIncreasing = true;

    private void Start()
    {
        
        hungerSlider.value = Random.Range(minValue, maxValue);
    }

    private void Update()
    {
        
        if (isIncreasing)
        {
            hungerSlider.value += hungerIncreaseRate * Time.deltaTime;
        }
        else
        {
            hungerSlider.value -= hungerDecreaseRate * Time.deltaTime;
        }

        
        hungerSlider.value = Mathf.Clamp(hungerSlider.value, minValue, maxValue);

        
        if (hungerSlider.value < 0.3f)
        {
            hungerImage.gameObject.SetActive(true);
        }
        else
        {
            hungerImage.gameObject.SetActive(false);
        }

        
        if (hungerSlider.value >= maxValue || hungerSlider.value <= minValue)
        {
            isIncreasing = !isIncreasing;
        }
    }
}