using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotsClass : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventorySystem manager;
    public SlotManagerScript item;

    public void Init(InventorySystem inventoryManager)
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
