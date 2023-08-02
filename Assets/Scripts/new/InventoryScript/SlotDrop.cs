using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class SlotDrop : MonoBehaviour, IDropHandler
{
    // �ڽſ��� ��ӵ� ������ ���� �� �� ���԰� �ڽ��� ������ ������ �ٲ�.

    private InventorySlotsClass slot;

    private void Start()
    {
        slot = GetComponent<InventorySlotsClass>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        var temp = this.slot.slotItem;
        if(GameData.droppedObejct.GetComponent<InventorySlotsClass>() != null)
        {
            this.slot.slotItem = GameData.droppedObejct.GetComponent<InventorySlotsClass>().slotItem;
            GameData.droppedObejct.GetComponent<InventorySlotsClass>().slotItem = temp;
        }
        else
        {
            this.slot.slotItem = GameData.droppedObejct.GetComponent<MiniInventorySlot>().slotItem;
            GameData.droppedObejct.GetComponent<MiniInventorySlot>().slotItem = temp;
        }
        
        GameData.droppedObejct = null;
    }
}
