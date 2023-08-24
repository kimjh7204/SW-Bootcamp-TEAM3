using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBar2 : MonoBehaviour
{
    

    [Header("길이 조절 할 이미지")]
    public RectTransform stateBar2;

    [Header("원래 크기")]
    public float width;
    public float height;

    [Header("줄어드는 속도")]
    public float thirstSpeed;

    public static StateBar2 instance;
    public float thirst = 100;

    [Header("game over panel")]
    public GameObject gameoverPanel;

    private void Awake()
    {
        instance = this;
        thirst = height;
    }


    void FixedUpdate()
    {

        if (thirst > height)
        {
            thirst = height;
        }
        else if (thirst > 0)
        {
            thirst -= thirstSpeed;

        }
        else if (thirst <= 0)
        {
            thirst = 0;
            gameoverPanel.SetActive(true);
        }

        stateBar2.sizeDelta = new Vector2(width, thirst);
    }

    public void Drink(float water)
    {
        thirst += water;
    }
    
    
    public int GetThirst()
    {
        return Mathf.FloorToInt(thirst);
    }

}
