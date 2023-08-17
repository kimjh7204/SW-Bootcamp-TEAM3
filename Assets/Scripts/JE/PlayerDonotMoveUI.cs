using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDonotMoveUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // 클릭했을 때 플레이어가 움직이면 안되는 UI에 넣을 스크립트

    public void OnPointerEnter(PointerEventData eventData)
    {
        NavData.playerCanMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        NavData.playerCanMove = true;
    }
}
