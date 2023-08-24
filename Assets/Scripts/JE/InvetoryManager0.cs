using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InvetoryManager0 : MonoBehaviour
{
    public static InvetoryManager0 InventoryManagerInstance;
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

    public List<ItemSlot0> itemSlots = new List<ItemSlot0>();

    [Header("�̴� ��ư â")]
    public GameObject miniButtons;

    [Header("�κ��丮 ���� á���� �˷��ִ� �г�")]
    public GameObject inventoryFullPanel;

    //public List<string> itemKeys;
    public List<Item> itemDatas;

    public Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

    private void Awake()
    {
        InventoryManagerInstance = this;
        inventoryFullPanel.SetActive(false);
        for (var i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].Init(this);
        }

        for (var i = 0; i < itemDatas.Count; i++)
        {
            itemDictionary.Add(itemDatas[i].itemName, itemDatas[i]);
        }
        
        /*SetItem(testItem1);
        SetItem(testItem2);
        SetItem(testItem3);*/
        
    }

    public string[] GetKeys()
    {
        List<string> tempItem = new List<string>();
        foreach (var itemSlot0 in itemSlots)
        {
            if (itemSlot0.item != null)
            {
                tempItem.Add(itemSlot0.item.itemData.itemName);
            }
        }

        return tempItem.ToArray();
    }
    
    public void SetItem(string key)
    {
        SetItem(itemDictionary[key]);
    }
    
    public void SetItem(Item item)
    {
        //itemUIPrefab
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

    public void SetItemIndex(int idx, Item item)
    {
        if (itemSlots[idx].item != null)
        {
            itemSlots[idx].item.DeleteUI();
        }
        GameObject tempItemUI = Instantiate(itemUIPrefab, itemSlots[idx].transform);
        ItemUI0 temp = tempItemUI.GetComponent<ItemUI0>();
        Item tempItemData = item;
        temp.Init(tempItemData, this, itemSlots[idx], miniButtons);

    }

    public ItemUI0 SetItemAndReturnUI(Item item)
    {
        // SetItem() UI return
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
        // �κ��丮�� ����á���� Ȯ���ϴ� �Լ�
        // ���� á���� true, ��������� false return  (���� �̴��κ��丮�� ������)
        for (int i = 3; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].item == null)
                return false;
        }
        return true;
    }

    public void NoticeInventoryFull()
    {
        // �κ��丮�� ���� á���� �˷��ִ� �Լ�
        inventoryFullPanel.SetActive(true);
    }
    
}
