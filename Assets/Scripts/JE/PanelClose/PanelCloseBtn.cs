using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCloseBtn : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void PanelCloseBtnClick()
    {
        panel.SetActive(false);
    }
}
