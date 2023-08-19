using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class ItemUI0 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerExitHandler, IPointerEnterHandler
{
    public Item itemData;
    private Image itemImage;
    private RectTransform rectTransform;

    // 미니버튼창
    private GameObject miniButtons;


    private InvetoryManager0 invetoryManager;
    private ItemSlot0 itemSlot;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void Init(Item data, InvetoryManager0 manager, ItemSlot0 slot, GameObject panel)
    {
        itemData = data;
        itemImage = GetComponent<Image>();
        itemImage.sprite = itemData.itemImage;

        invetoryManager = manager;
        itemSlot = slot;
        itemSlot.item = this;
        miniButtons = panel;
    }


    //-------------------------------------------------------------------


    public void OnPointerDown(PointerEventData eventData)
    {
        invetoryManager.draggingItem = this;
        invetoryManager.draggingItemUI = this;
        itemImage.raycastTarget = false;
        
        rectTransform.SetParent(invetoryManager.dragLayer);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        //--------
        // 조합
        if (invetoryManager.isOnObjRotate && invetoryManager.showedItem != null)
        {
            if (invetoryManager.draggingItem == null) return;
            
            for (int i = 0; i < invetoryManager.showedItem.combination.Length; i++)
            {
                if (invetoryManager.showedItem.combination[i].inputItem == invetoryManager.draggingItem.itemData)
                {
                    if(invetoryManager.IsInventoryFUll())
                    {
                        invetoryManager.NoticeInventoryFull();
                        break;
                    }
                    // 두개 없애고
                    invetoryManager.showedItemUI.DeleteUI();
                    if (invetoryManager.draggingItem.itemData.itemTag != Item.ItemTag.tool)
                        invetoryManager.draggingItemUI.DeleteUI();
                    // resultItem UI 생성
                    var tempUI = invetoryManager.SetItemAndReturnUI(invetoryManager.showedItem.combination[i].resultItem);
                    // resultItem object 생성
                    CreateObject(invetoryManager.showedItem.combination[i].resultItem, 1);
                    invetoryManager.showedItem = invetoryManager.showedItem.combination[i].resultItem;
                    invetoryManager.showedItemUI = tempUI;
                    break;
                }
            }
        }

        //--------

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


        

        if (Input.GetMouseButtonUp(0) && itemSlot == invetoryManager.selectedSlot)
        {
            // 좌클릭(buttonUp)
            // 3D 오브젝트 생성
            if (itemData != null)
            {
                CreateObject(itemData);
            }
        }

        if(Input.GetMouseButtonUp(1))
        {
            // 우클릭(buttonUp)
            // 미니 버튼 창 나타나게
            miniButtons.transform.position = eventData.position;
            miniButtons.GetComponent<MiniButtons>().SetItemUI(this);
            miniButtons.SetActive(true);
        }


        
    }

    private void CreateObject(Item itemData, float i = 0)
    {
        if (invetoryManager.showedObject != null)
        {
            Destroy(invetoryManager.showedObject);
            invetoryManager.tooltipText.text = null;
        }
        invetoryManager.showedObject = Instantiate<GameObject>(itemData.itemShowObject, new Vector3(-0.0026165843f, -53.3899994f, 0), Quaternion.identity);
        //invetoryManager.showedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        invetoryManager.tooltipText.text = itemData.itemTooltip;
        if(i==0)
        {
            invetoryManager.showedItem = itemData;
            invetoryManager.showedItemUI = this;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
       // NavData.playerCanMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 미니 버튼 창 꺼주기
        miniButtons.SetActive(false);

        //NavData.playerCanMove = true;

    }

    //-------------------------
    public void DeleteUI()
    {
        itemSlot.item = null;
        Destroy(this.gameObject);
        return;
    }
}
