using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealInventory : MonoBehaviour
{
    // ���� �����ϰ� ������ �߰��ϴ� �Լ�
    // ������ �� ���� ������.

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
                print("������ ���� �� �ֽ��ϴ�.");
            }
        }

    }
}
