using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotManagerScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Item slotItemData;
    private Image itemImage;
    private RectTransform rectTransform;

    private InventorySystem invetoryManager;
    private InventorySlotsClass itemSlot;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Init(Item data, InventorySystem manager, InventorySlotsClass slot)
    {
        slotItemData = data;
        itemImage = GetComponent<Image>();
        itemImage.sprite = slotItemData.itemImage;

        invetoryManager = manager;
        itemSlot = slot;
        itemSlot.item = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        invetoryManager.tooltip.SetTooltip(rectTransform.position, slotItemData.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        invetoryManager.tooltip.Disable();
    }

    //-------------------------------------------------------------------


    public void OnPointerDown(PointerEventData eventData)
    {
        invetoryManager.dragItem = this;
        itemImage.raycastTarget = false;
        
        rectTransform.SetParent(invetoryManager.dragLayer);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        invetoryManager.dragItem = null;

        if (invetoryManager.selectedSlot == null)
        {
            rectTransform.SetParent(itemSlot.transform);
        }
        else
        {
            if (invetoryManager.selectedSlot.item == null)
            {
                itemSlot.item = null;
                rectTransform.SetParent(invetoryManager.selectedSlot.transform);
                itemSlot = invetoryManager.selectedSlot;
            }
            else //Item Swap
            {
                invetoryManager.selectedSlot.item.ChangeSlot(itemSlot);
                ChangeSlot(invetoryManager.selectedSlot);
            }
            
        }

        rectTransform.localPosition = Vector3.zero;
        itemImage.raycastTarget = true;
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
