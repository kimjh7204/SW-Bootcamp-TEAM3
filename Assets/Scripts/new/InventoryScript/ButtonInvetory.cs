using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class ButtonInvetory : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    // ������ �� �κ��丮 �г� ���ְ�
    // ��ư ������ �κ��丮 ���� �״� ����

    public GameObject Inventorypanel;
    public bool isMouseExitButton = false;



    private void Start()
    {
        Inventorypanel.SetActive(false);
        GameData.isInventoryOpen = false;
    }

    public void OnClick()
    {
        if (GameData.isInventoryOpen)
        {
            Inventorypanel.SetActive(false);
            GameData.isInventoryOpen = false;
            
            PlayerController.playerCanMove = true;
            

        }
        else
        {
            Inventorypanel.SetActive(true);
            GameData.isInventoryOpen = true;
            PlayerController.playerCanMove = false;
        }

    }


    public void OnPointerExit(PointerEventData eventData)
    {
        /*isMouseExitButton = true;
        if(!GameData.isInventoryOpen)
        {
            NavData.playerCanMove = true;
        }*/

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        /*isMouseExitButton = false;
        NavData.playerCanMove = false;*/
    }
}
