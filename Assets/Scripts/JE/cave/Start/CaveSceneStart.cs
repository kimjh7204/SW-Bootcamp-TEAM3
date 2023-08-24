using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSceneStart : MonoBehaviour
{
    public InvetoryManager0 inventoryManager;
    public GameObject player;

    void Start()
    {
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

        if (GameData.playerWasInCave)
        {
            player.transform.position = new Vector3(-52.9300003f, 18.9599991f, -34.0999985f);
            player.transform.Rotate(new Vector3(0, -190f, 0));
            GameData.playerWasInCave = false;
        }

    }

}
