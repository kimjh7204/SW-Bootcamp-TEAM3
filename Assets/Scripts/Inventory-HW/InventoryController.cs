using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject itemUIPrefab;
    public RectTransform inventoryPanel;
    public RectTransform dragLayer;

    public InventoryTools tools;

    private Itemtxt _draggingItem = null;
    public Itemtxt draggingItem
    {
        get => _draggingItem;
        set => _draggingItem = value;
    }

    private ItemSlot5 _selectedSlot = null;
    public ItemSlot5 selectedSlot
    {
        get => _selectedSlot;
        set => _selectedSlot = value;
    }
    
    [SerializeField] private List<ItemSlot5> itemSlots = new List<ItemSlot5>();

    private void Start()
    {
        for(var i = 0;  i < itemSlots.Count; i++)
        {
            itemSlots[i].Init(this);
        }

        SetItem("Item2");
        SetItem("Item1");
    }

    public void SetItem(string itemName)
    {
        foreach (var itemSlot5 in itemSlots)
        {
            if (itemSlot5.item == null)
            {
                GameObject tempItemUI = Instantiate(itemUIPrefab, itemSlot5.transform);
                Itemtxt temp = tempItemUI.GetComponent<Itemtxt>();
                Item5 tempItemData = Resources.Load<Item5>("Items/" + itemName);
                temp.Init(tempItemData, this, itemSlot5);
                break;
            }
        }
    }
}