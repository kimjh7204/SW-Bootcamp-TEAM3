using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemUI0 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Item itemData;
    private Image itemImage;
    private RectTransform rectTransform;


    private InvetoryManager0 invetoryManager;
    private ItemSlot0 itemSlot;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void Init(Item data, InvetoryManager0 manager, ItemSlot0 slot)
    {
        itemData = data;
        itemImage = GetComponent<Image>();
        itemImage.sprite = itemData.itemImage;

        invetoryManager = manager;
        itemSlot = slot;
        itemSlot.item = this;
    }


    //-------------------------------------------------------------------


    public void OnPointerDown(PointerEventData eventData)
    {
        invetoryManager.draggingItem = this;
        itemImage.raycastTarget = false;
        
        rectTransform.SetParent(invetoryManager.dragLayer);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        invetoryManager.draggingItem = null;

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
                itemSlot.item = this;
            }
            else //Item Swap
            {
                invetoryManager.selectedSlot.item.ChangeSlot(itemSlot);
                ChangeSlot(invetoryManager.selectedSlot);
            }
            
        }

        rectTransform.localPosition = Vector3.zero;
        itemImage.raycastTarget = true;



        //3D 오브젝트 생성
        if (itemData != null)
        {
            if (invetoryManager.showedObject != null)
            {
                Destroy(invetoryManager.showedObject);
                invetoryManager.tooltipText.text = null;
            }
            invetoryManager.showedObject = Instantiate<GameObject>(itemData.itemGameObject, new Vector3(-0.0026165843f, -53.3899994f, 0), Quaternion.identity);
            invetoryManager.tooltipText.text = itemData.itemTooltip;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    private void ChangeSlot(ItemSlot0 slot)
    {
        slot.item = this;
        rectTransform.SetParent(slot.transform);
        itemSlot = slot;
        rectTransform.localPosition = Vector3.zero;
    }
}
