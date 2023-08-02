using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject slotUIPrefab;
    public RectTransform inventoryPanelLayer;
    public RectTransform slotDragLayer;

    public ScriptTooltip tooltip;

    private SlotManagerScript _dragItem = null;
    public SlotManagerScript dragItem
    {
        get => _dragItem;
        set => _dragItem = value;
    }

    private InventorySlotsClass _enteredSlot = null;
    public InventorySlotsClass enteredSlot
    {
        get => _enteredSlot;
        set => _enteredSlot = value;
    }
    
    [SerializeField] private List<InventorySlotsClass> itemSlots = new List<InventorySlotsClass>();

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
        foreach (var itemSlot in itemSlots)
        {
            if (itemSlot.item == null)
            {
                GameObject tempItemUI = Instantiate(slotUIPrefab, itemSlot.transform);
                SlotManagerScript temp = tempItemUI.GetComponent<SlotManagerScript>();
                Item tempItemData = Resources.Load<Item>("Items/" + itemName);
                temp.Init(tempItemData, this, itemSlot);
                break;
            }
        }
    }
}
