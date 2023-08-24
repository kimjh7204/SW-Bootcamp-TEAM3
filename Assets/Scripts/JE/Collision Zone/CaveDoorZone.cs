using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveDoorZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Game Scene End ------------------------------
            GameData.hungry = StateBar1.instance.hungry;
            GameData.thirsty = StateBar2.instance.thirst;

            for (int i = 0; i < InvetoryManager0.InventoryManagerInstance.itemSlots.Count; i++)
            {
                if (InvetoryManager0.InventoryManagerInstance.itemSlots[i].item != null)
                    GameData.inventoryItems[i] = InvetoryManager0.InventoryManagerInstance.itemSlots[i].item.itemData;
            }

            //----------------------------------------------
            SceneManager.LoadScene(2);
        }
    }
}
