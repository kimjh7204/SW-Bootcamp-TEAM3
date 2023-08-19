using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InvetoryManager0 : MonoBehaviour
{
    public Item testItem1;
    public Item testItem2;
    public Item testItem3;

    public bool isOnObjRotate = false;

    public TextMeshProUGUI tooltipText;

    public GameObject itemUIPrefab;
    public RectTransform inventoryPanel;
    public RectTransform dragLayer;

    public GameObject showedObject = null;

    private ItemUI0 _draggingItem = null;
    public ItemUI0 draggingItem
    {
        get => _draggingItem;
        set => _draggingItem = value;
    }

    public Item showedItem;

    public ItemUI0 showedItemUI = null;

    public ItemUI0 draggingItemUI = null;

    private ItemSlot0 _selectedSlot = null;
    public ItemSlot0 selectedSlot
    {
        get => _selectedSlot;
        set => _selectedSlot = value;
    }

    [SerializeField] private List<ItemSlot0> itemSlots = new List<ItemSlot0>();

    [Header("미니 버튼 창")]
    public GameObject miniButtons;

    [Header("인벤토리 가득 찼음을 알려주는 패널")]
    public GameObject inventoryFullPanel;

    private void Start()
    {
        inventoryFullPanel.SetActive(false);
        for (var i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].Init(this);
        }

        SetItem(testItem1);
        SetItem(testItem2);
        SetItem(testItem3);
    }

    public void SetItem(Item item)
    {
        // 인벤토리의 빈 슬롯에 itemUIPrefab 생성해서 넣는다
        for (int i = 3; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].item == null)
            {
                GameObject tempItemUI = Instantiate(itemUIPrefab, itemSlots[i].transform);
                ItemUI0 temp = tempItemUI.GetComponent<ItemUI0>();
                Item tempItemData = item;
                temp.Init(tempItemData, this, itemSlots[i], miniButtons);

                break;
            }
        }
    }

    public ItemUI0 SetItemAndReturnUI(Item item)
    {
        // SetItem()과 똑같은데 생성한 UI를 return한다
        for (int i = 3; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].item == null)
            {
                GameObject tempItemUI = Instantiate(itemUIPrefab, itemSlots[i].transform);
                ItemUI0 temp = tempItemUI.GetComponent<ItemUI0>();
                Item tempItemData = item;
                temp.Init(tempItemData, this, itemSlots[i], miniButtons);
                return temp;
            }
        }
        return null;
    }

    public bool IsInventoryFUll()
    {
        // 인벤토리가 가득찼는지 확인하는 함수
        // 가득 찼으면 true, 비어있으면 false return  (위의 미니인벤토리는 제외임)
        for (int i = 3; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].item == null)
                return false;
        }
        return true;
    }

    public void NoticeInventoryFull()
    {
        // 인벤토리가 가득 찼음을 알려주는 함수
        inventoryFullPanel.SetActive(true);
    }
}
