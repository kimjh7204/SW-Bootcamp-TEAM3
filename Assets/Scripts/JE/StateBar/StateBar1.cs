using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBar1 : MonoBehaviour
{
    public RectTransform stateBar1;
    public float width;
    public float height;
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
