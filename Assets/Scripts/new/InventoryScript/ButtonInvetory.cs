using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class ButtonInvetory : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    // 시작할 때 인벤토리 패널 꺼주고
    // 버튼 누르면 인벤토리 껐다 켰다 해줌

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
