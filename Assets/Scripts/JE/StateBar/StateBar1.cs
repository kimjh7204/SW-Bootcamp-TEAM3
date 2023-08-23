using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBar1 : MonoBehaviour
{
    [Header("길이 조절할 이미지")]
    public RectTransform stateBar1;

    [Header("원래 크기")]
    public float width;
    public float height;

    [Header("줄어드는 속도")]
    public float hungrySpeed;

    public static StateBar1 instance;
    public float hungry;

    [Header("game over panel")]
    public GameObject gameoverPanel;

    private void Start()
    {
        instance = this;
        hungry = height;
    }


    void FixedUpdate()
    {
        
        if (hungry > height)
        {
            hungry = height;
        }
        else if (hungry > 0)
        {
            hungry -= hungrySpeed;

        }
        else if (hungry <= 0)
        {
            hungry = 0;
            gameoverPanel.SetActive(true);
        }

        stateBar1.sizeDelta = new Vector2(width, hungry);
    }

    public void EatFull(float full)
    {
        hungry += full;
    }
    
    public int GetHunger()
    {
        return Mathf.FloorToInt(hungry);
    }
}
