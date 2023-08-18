using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingPanelReleaseBtn : MonoBehaviour
{
    public GameObject fishingPanel;

    public void ReleaseBtnClick()
    {
        fishingPanel.SetActive(false);
    }

    private void Start()
    {
        fishingPanel.SetActive(false);
    }
}
