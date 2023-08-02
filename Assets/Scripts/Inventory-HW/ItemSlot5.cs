using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot5 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryController controll;
    public Itemtxt item;

    public void Init(InventoryController inventoryController)
    {
        controll = inventoryController;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        controll.selectedSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        controll.selectedSlot = null;
    }
}
