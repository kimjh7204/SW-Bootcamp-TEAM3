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

    //�޴��г� �ݱ��ư ���� playercanmove true���־����
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
