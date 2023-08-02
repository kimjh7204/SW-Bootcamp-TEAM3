using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotManagerScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Item slotItemData;
    private Image itemImageComp;
    private RectTransform rectTransformVariable;

    private InventorySystem inventorySystem;
    private InventorySlotsClass itemSlot;

    private void Start()
    {
        rectTransformVariable = GetComponent<RectTransform>();
    }

    public void Init(Item data, InventorySystem manager, InventorySlotsClass slot)
    {
        slotItemData = data;
        itemImageComp = GetComponent<Image>();
        itemImageComp.sprite = slotItemData.itemImage;

        inventorySystem = manager;
        itemSlot = slot;
        itemSlot.item = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventorySystem.tooltip.SetTooltip(rectTransformVariable.position, slotItemData.itemTooltip);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventorySystem.tooltip.Disable();
    }

    //-------------------------------------------------------------------


    public void OnPointerDown(PointerEventData eventData)
    {
        inventorySystem.dragItem = this;
        itemImageComp.raycastTarget = false;

        rectTransformVariable.SetParent(inventorySystem.slotDragLayer);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inventorySystem.dragItem = null;

        if (inventorySystem.enteredSlot == null)
        {
            rectTransformVariable.SetParent(itemSlot.transform);
        }
        else
        {
            if (inventorySystem.enteredSlot.item == null)
            {
                itemSlot.item = null;
                rectTransformVariable.SetParent(inventorySystem.enteredSlot.transform);
                itemSlot = inventorySystem.enteredSlot;
            }
            else //Item Swap
            {
                inventorySystem.enteredSlot.item.ChangeSlot(itemSlot);
                ChangeSlot(inventorySystem.enteredSlot);
            }
            
        }

        rectTransformVariable.localPosition = Vector3.zero;
        itemImageComp.raycastTarget = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransformVariable.position = eventData.position;
    }

    private void ChangeSlot(InventorySlotsClass slot)
    {
        slot.item = this;
        rectTransformVariable.SetParent(slot.transform);
        itemSlot = slot;
        rectTransformVariable.localPosition = Vector3.zero;
    }
}
