using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBar1 : MonoBehaviour
{
    [Header("���� ������ �̹���")]
    public RectTransform stateBar1;
    [Header("���� ũ��")]
    public float width;
    public float height;
    [Header("���� �ӵ�(��������� �ӵ�)")]
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

    public void eatFull(float full)
    {
        stateBar1.sizeDelta = new Vector2(width, height - hungrySpeed * i + full);
    }
}
