using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;

    /*private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            ContentController.instance.AddItem(item, this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ContentController.instance.DeleteItem(item);
    }*/

}