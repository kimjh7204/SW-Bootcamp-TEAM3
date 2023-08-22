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

    [Header("�̴� ��ư â")]
    public GameObject miniButtons;

    [Header("�κ��丮 ���� á���� �˷��ִ� �г�")]
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
        // �κ��丮�� �� ���Կ� itemUIPrefab �����ؼ� �ִ´�
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
        // SetItem()�� �Ȱ����� ������ UI�� return�Ѵ�
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
