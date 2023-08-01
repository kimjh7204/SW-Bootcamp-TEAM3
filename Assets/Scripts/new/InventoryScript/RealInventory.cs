using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealInventory : MonoBehaviour
{
    // 슬롯 정리하고 아이템 추가하는 함수
    // 시작할 때 슬롯 정리함.

    public List<Item> items;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private InventorySlot[] slots;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<InventorySlot>();
    }

    private void Awake()
    {
        FreshSlot();
    }

    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].slotItem = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].slotItem = null;
        }
    }

    public void AddItem(Item _item)
    {
        if (!GameData.isInventoryOpen)
        {
            if (items.Count < slots.Length)
            {
                if (_item.amount == 0)
                {
                    items.Add(_item);
                    FreshSlot();
                }

                _item.amount += 1;
            }
            else
            {
                print("슬롯이 가득 차 있습니다.");
            }
        }

    }
}
