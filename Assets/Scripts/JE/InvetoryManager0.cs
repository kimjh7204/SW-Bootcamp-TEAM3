using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InvetoryManager0 : MonoBehaviour
{
    public Item testItem1;
    public Item testItem2;

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

    private ItemSlot0 _selectedSlot = null;
    public ItemSlot0 selectedSlot
    {
        get => _selectedSlot;
        set => _selectedSlot = value;
    }
    
    [SerializeField] private List<ItemSlot0> itemSlots = new List<ItemSlot0>();

    private void Start()
    {
        for(var i = 0;  i < itemSlots.Count; i++)
        {
            itemSlots[i].Init(this);
        }

        SetItem(testItem1);
        SetItem(testItem2);
    }

    public void SetItem(Item item)
    {
        // 처음 획득하는 아이템이면 인벤토리의 빈 슬롯에 itemUIPrefab 생성해서 넣고
        // 아니라면 아이템 정보의 amount만 늘린다


        if(item.amount == 0)
        {
            for (int i = 3; i < itemSlots.Count; i++)
            {
                if (itemSlots[i].item == null)
                {
                    GameObject tempItemUI = Instantiate(itemUIPrefab, itemSlots[i].transform);
                    ItemUI0 temp = tempItemUI.GetComponent<ItemUI0>();
                    Item tempItemData = item;
                    temp.Init(tempItemData, this, itemSlots[i]);

                    //item.amount = 1;  // 아이템 amount 1 늘린다
                    break;
                }
            }
        }
        else
        {  // 아이템이 이미 1개 이상 있다면 인벤토리에 넣지 않고 아이템 amount만 1만큼 늘린다
            item.amount += 1;
        }
        
    }
}
