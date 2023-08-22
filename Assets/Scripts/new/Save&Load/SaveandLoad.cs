using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveandLoad : MonoBehaviour
{
    public TextMeshProUGUI Day;
    public Image hunger;
    public Image thirst;
    public GameObject playerObject;

    void Start()
    {
        LoadData();
        UpdateUI();
    }


    public void Save()
    {
        DataManager.instance.SaveData(); 
    }

    private void UpdateUI()
    {
        hunger.fillAmount = (StateBar1.instance.GetHunger() / (float)StateBar1.instance.height)*100;
        thirst.fillAmount = (StateBar2.instance.GetThirst() / (float)StateBar2.instance.height)*100;
    }


    private void SaveData()
    {
        DataManager.instance.nowPlayer.playerPosition = playerObject.transform.position;
        DataManager.instance.nowPlayer.amountofhunger = StateBar1.instance.GetHunger();
        DataManager.instance.nowPlayer.thirstLevel = StateBar2.instance.GetThirst();
        DataManager.instance.SaveData();
    }

    private void LoadData()
    {
        DataManager.instance.LoadData();
        playerObject.transform.position = DataManager.instance.nowPlayer.playerPosition;

        StateBar1.instance.hungry = DataManager.instance.nowPlayer.amountofhunger;
        StateBar2.instance.thirst = DataManager.instance.nowPlayer.thirstLevel;

        UpdateUI();
    }





}
