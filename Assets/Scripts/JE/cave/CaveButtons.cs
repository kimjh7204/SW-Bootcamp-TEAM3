using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveButtons : MonoBehaviour
{
    public GameObject exitPanel;

    void Start()
    {
        exitPanel.SetActive(false);
    }

    public void YesButtonClick()
    {
        // scene ÀüÈ¯
    }

    public void NoButtonClick()
    {
        exitPanel.SetActive(false);
    }
}
