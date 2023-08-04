using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDoNotMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        NavData.playerCanMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }


}
