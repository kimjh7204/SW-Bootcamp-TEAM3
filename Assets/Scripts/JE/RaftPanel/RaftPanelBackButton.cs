using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftPanelBackButton : MonoBehaviour
{
    public GameObject raftPanel;

    public void RaftPanelBackButtonClick()
    {
        raftPanel.SetActive(false);
    }
}
