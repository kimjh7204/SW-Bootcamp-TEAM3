using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotsClass : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventorySystem manage;
    public SlotManagerScript item;

    public void Init(InventorySystem inventoryManager)
    {
        manage = inventoryManager;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        manage.enteredSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        manage.enteredSlot = null;
    }
}
