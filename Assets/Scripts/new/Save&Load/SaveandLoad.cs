using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveandLoad : MonoBehaviour
{
    public TextMeshProUGUI Day;
    public GameObject playerObject;

    void Start()
    {
        LoadData();
    }

    public void Save()
    {
        SaveData();
        DataManager.instance.SaveData();
    }


    private void SaveData()
    {
        DataManager.instance.nowPlayer.playerPosition = playerObject.transform.position;
        DataManager.instance.nowPlayer.amountofhunger = StateBar1.instance.GetHunger();
        DataManager.instance.nowPlayer.thirstLevel = StateBar2.instance.GetThirst();
        DataManager.instance.nowPlayer.item = InvetoryManager0.InventoryManagerInstance.GetKeys();
        DataManager.instance.SaveData();
    }

    public void LoadData()
    {

        if (!File.Exists(DataManager.instance.path + DataManager.instance.nowSlot)) return;
        
        DataManager.instance.LoadData();

        playerObject.transform.position = DataManager.instance.nowPlayer.playerPosition;
        foreach (var i in DataManager.instance.nowPlayer.item)
        {
            InvetoryManager0.InventoryManagerInstance.SetItem(i);
        }

        if (DataManager.instance.nowPlayer.amountofhunger != 0) StateBar1.instance.hungry = DataManager.instance.nowPlayer.amountofhunger;
        if (DataManager.instance.nowPlayer.thirstLevel != 0) StateBar2.instance.thirst = DataManager.instance.nowPlayer.thirstLevel;

    }
}
