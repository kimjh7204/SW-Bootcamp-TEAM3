using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot0 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InvetoryManager0 manager;
    public ItemUI0 item;


    public void Init(InvetoryManager0 inventoryManager)
    {
        manager = inventoryManager;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        manager.selectedSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        manager.selectedSlot = null;
    }

    
}
