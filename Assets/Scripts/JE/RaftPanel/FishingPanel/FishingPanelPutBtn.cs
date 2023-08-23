using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingPanelPutBtn : MonoBehaviour
{
    [Header("연결해주세요")]
    public InvetoryManager0 inventoryManager;
    public GameObject fishingPanel;

    [Header("낚시로 잡는 물고기(아이템)")]
    public Item fish;

    public void PutBtnClick()
    {
        if(inventoryManager.IsInventoryFUll())
        {
            inventoryManager.NoticeInventoryFull();
        }
        else
        {
            inventoryManager.SetItem(fish);
            fishingPanel.SetActive(false);
        }
        
    }
}
