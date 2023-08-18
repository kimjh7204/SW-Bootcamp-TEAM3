using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingPanelPutBtn : MonoBehaviour
{
    [Header("�������ּ���")]
    public InvetoryManager0 inventoryManager;
    public GameObject fishingPanel;

    [Header("���÷� ��� �����(������)")]
    public Item fish;

    public void PutBtnClick()
    {
        inventoryManager.SetItem(fish);
        fishingPanel.SetActive(false);
    }
}
