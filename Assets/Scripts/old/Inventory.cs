using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    /*// Start is called before the first frame update
    public List<Item> items;

    [SerializeField]
    private Transform slotParent; // bag 이 담기는 곳.
    [SerializeField]
    private InventorySlot[] slots; //bag ������ slot �ڵ����� ä����

    private Vector3 DefaultPos;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<InventorySlot>();
    }

    void Awake()
    {
        FreshSlot();
    }

    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void AddItem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            print("슬롯이 가득 차 있습니다.");
        }
    }*/
}
