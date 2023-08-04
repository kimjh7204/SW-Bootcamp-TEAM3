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
    [Header("조절 속도(배고파지는 속도)")]
    public float hungrySpeed;
    private float i = 1;

    void FixedUpdate()
    {
        if(height - hungrySpeed * i >= 0)
        {
            stateBar1.sizeDelta = new Vector2(width, height - hungrySpeed * i);
            i += 1;
        }
    }
}
