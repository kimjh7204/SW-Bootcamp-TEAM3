using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Itemtxt : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Item5 itemData;
    private Image itemImage;
    private RectTransform rectTransform;

    private InventoryController inventoryController;
    private ItemSlot5 itemSlot5;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Init(Item5 data5, InventoryController controll, ItemSlot5 slot5)
    {
        itemData = data5;
        itemImage = GetComponent<Image>();
        itemImage.sprite = itemData.itemImage;

        inventoryController = controll;
        itemSlot5 = slot5;
        itemSlot5.item = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryController.tools.SetInventoryTools(rectTransform.position, itemData.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventoryController.tools.Disable();
    }

    //-------------------------------------------------------------------


    public void OnPointerDown(PointerEventData eventData)
    {
        inventoryController.draggingItem = this;
        itemImage.raycastTarget = false;
        
        rectTransform.SetParent(inventoryController.dragLayer);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inventoryController.draggingItem = null;

        if (inventoryController.selectedSlot == null)
        {
            rectTransform.SetParent(itemSlot5.transform);
        }
        else
        {
            if (inventoryController.selectedSlot.item == null)
            {
                itemSlot5.item = null;
                rectTransform.SetParent(inventoryController.selectedSlot.transform);
                itemSlot5 = inventoryController.selectedSlot;
            }
            else 
            {
                inventoryController.selectedSlot.item.ChangeSlot(itemSlot5);
                ChangeSlot(inventoryController.selectedSlot);
            }
            
        }

        rectTransform.localPosition = Vector3.zero;
        itemImage.raycastTarget = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    private void ChangeSlot(ItemSlot5 slot5)
    {
        slot5.item = this;
        rectTransform.SetParent(slot5.transform);
        itemSlot5 = slot5;
        rectTransform.localPosition = Vector3.zero;
    }
}
