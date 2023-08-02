using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class SlotDropMini : MonoBehaviour, IDropHandler
{
    // �ڽſ��� ��ӵ� ������ ���� �� �� ���԰� �ڽ��� ������ ������ �ٲ�.

    private MiniInventorySlot slot;

    private void Start()
    {
        slot = GetComponent<MiniInventorySlot>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        var temp = this.slot.slotItem;
        if(GameData.droppedObejct != null)
        {
            if (GameData.droppedObejct.GetComponent<InventorySlotsClass>() != null)
            {
                this.slot.slotItem = GameData.droppedObejct.GetComponent<InventorySlotsClass>().slotItem;
                GameData.droppedObejct.GetComponent<InventorySlotsClass>().slotItem = temp;
            }
            else
            {
                this.slot.slotItem = GameData.droppedObejct.GetComponent<MiniInventorySlot>().slotItem;
                GameData.droppedObejct.GetComponent<MiniInventorySlot>().slotItem = temp;
            }
        }
        
        GameData.droppedObejct = null;
    }
}
