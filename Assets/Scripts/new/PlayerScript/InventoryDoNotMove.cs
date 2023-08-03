using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDoNotMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        NavData.playerCanMove = false;
        Debug.Log("�κ��丮 �ȿ� ���콺 -> false");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }


}
