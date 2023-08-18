using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannotPanelCloseBtn : MonoBehaviour
{
    public GameObject youCannotGoPanel;

    public void CannotPannelCloseBtnClick()
    {
        youCannotGoPanel.SetActive(false);
    }
}
