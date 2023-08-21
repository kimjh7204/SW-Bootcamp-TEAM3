using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
    public static ItemUI0 itemUI;  // battery lantern UI
    public GameObject playerLight;
    public static bool isLightOn;  // 불 켜져있는지
    public static PlayerLightController instance;

    void Start()
    {
        instance = this;
        if (isLightOn) playerLight.SetActive(true);
        else playerLight.SetActive(false);
    }

    public void LightUse()
    {
        playerLight.SetActive(!isLightOn);
        isLightOn = !isLightOn;
        
    }

    private void Update()
    {
        if(itemUI == null)
        {
            playerLight.SetActive(false);
            isLightOn = false;
        }
    }
}
