using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCloseButton : MonoBehaviour
{
    public GameObject menuPanel;
    public void MenuCloseButtonClick()
    {
        menuPanel.SetActive(false);
        GameData.isMenuPanelOpen = false;
        PlayerController.playerCanMove = true;
    }

    public void HomeButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    
}
