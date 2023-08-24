using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSceneStart : MonoBehaviour
{
    public InvetoryManager0 inventoryManager;
    void Start()
    {
        Debug.Log(GameData.hungry);
        if (GameData.hungry != 0)
        StateBar1.instance.hungry = GameData.hungry;
        if (GameData.thirsty != 0)
        StateBar2.instance.thirst = GameData.thirsty;

        for (int i = 0; i < GameData.inventoryItems.Length; i++)
        {
            if (GameData.inventoryItems[i] != null)
            {
                inventoryManager.SetItemIndex(i, GameData.inventoryItems[i]);
            }
            
        }

    }

}
