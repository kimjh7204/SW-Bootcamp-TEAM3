using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InvetoryManager manager;
    public Itemtxt item;

    public void Init(InventoryController inventoryManager)
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
