using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{
    public Item item;
    //private ContentController instance; // 나중에 변경.

    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("콜리전 발생");
        if (player.CompareTag("Player"))
        {
            ContentController.instance.AddItem(item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ContentController.instance.DeleteItem(item);
    }

}