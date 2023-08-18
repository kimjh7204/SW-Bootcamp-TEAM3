using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewPanelPlayerDoNotMove : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public void OnPointerExit(PointerEventData eventData)
    { // 미니창 슬롯 범위를 클릭했을 때 플레이어가 의도치 않게 움직이는 것을 막기 위함.
        PlayerController.playerCanMove = false;  //+
    }

    public void OnPointerEnter(PointerEventData eventData)
    { // 미니창 슬롯 범위를 클릭했을 때 플레이어가 의도치 않게 움직이는 것을 막기 위함.
        PlayerController.playerCanMove = true;  //+
    }
}
