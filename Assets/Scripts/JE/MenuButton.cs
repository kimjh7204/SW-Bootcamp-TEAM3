using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject menuPanel;

    private void Start()
    {
        menuPanel.SetActive(false);
    }

    //메뉴패널 닫기버튼 만들어서 playercanmove true해주어야함
    public void MenuButtonClick()
    {
        menuPanel.SetActive(true);
        GameData.isMenuPanelOpen = true;
        PlayerController.playerCanMove = false; //
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        /*if(!GameData.isMenuPanelOpen)
        {
            NavData.playerCanMove = true;
        }*/
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //NavData.playerCanMove = false;
    }
}
