using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotManagerScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Item itemData;
    private Image itemImageComp;
    private RectTransform rectTransform;

    private InvetorySystem invetorySystem;
    private InventorySlotsClass itemSlot;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Init(Item data, InvetorySystem manager, InventorySlotsClass slot)
    {
        itemData = data;
        itemImageComp = GetComponent<Image>();
        itemImageComp.sprite = itemData.itemImage;

        invetorySystem = manager;
        itemSlot = slot;
        itemSlot.item = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        invetorySystem.tooltip.SetTooltip(rectTransform.position, itemData.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        invetorySystem.tooltip.Disable();
    }

    //-------------------------------------------------------------------


    public void OnPointerDown(PointerEventData eventData)
    {
        invetorySystem.dragItem = this;
        itemImageComp.raycastTarget = false;
        
        rectTransform.SetParent(invetorySystem.dragLayer);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        invetorySystem.dragItem = null;

        if (invetorySystem.selectedSlot == null)
        {
            rectTransform.SetParent(itemSlot.transform);
        }
        else
        {
            if (invetorySystem.selectedSlot.item == null)
            {
                itemSlot.item = null;
                rectTransform.SetParent(invetorySystem.selectedSlot.transform);
                itemSlot = invetorySystem.selectedSlot;
            }
            else //Item Swap
            {
                invetorySystem.selectedSlot.item.ChangeSlot(itemSlot);
                ChangeSlot(invetorySystem.selectedSlot);
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
