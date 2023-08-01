using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class SlotDrop : MonoBehaviour, IDropHandler
{
    // 자신에게 드롭된 슬롯이 있을 때 그 슬롯과 자신의 아이템 정보를 바꿈.

    private InventorySlot slot;

    private void Start()
    {
        slot = GetComponent<InventorySlot>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        var temp = this.slot.slotItem;
        this.slot.slotItem = GameData.droppedObejct.GetComponent<InventorySlot>().slotItem;
        GameData.droppedObejct.GetComponent<InventorySlot>().slotItem = temp;
        GameData.droppedObejct = null;
    }
}
