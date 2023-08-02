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
        inventorySystem.tooltip.SetTooltip(rectTransform.position, slotItemData.description);
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
        
        rectTransform.SetParent(inventorySystem.dragLayer);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inventorySystem.dragItem = null;

        if (inventorySystem.selectedSlot == null)
        {
            rectTransform.SetParent(itemSlot.transform);
        }
        else
        {
            if (inventorySystem.selectedSlot.item == null)
            {
                itemSlot.item = null;
                rectTransform.SetParent(inventorySystem.selectedSlot.transform);
                itemSlot = inventorySystem.selectedSlot;
            }
            else //Item Swap
            {
                inventorySystem.selectedSlot.item.ChangeSlot(itemSlot);
                ChangeSlot(inventorySystem.selectedSlot);
            }
            
        }

        rectTransform.localPosition = Vector3.zero;
        itemImageComp.raycastTarget = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    private void ChangeSlot(InventorySlotsClass slot)
    {
        slot.item = this;
        rectTransform.SetParent(slot.transform);
        itemSlot = slot;
        rectTransform.localPosition = Vector3.zero;
    }
}
