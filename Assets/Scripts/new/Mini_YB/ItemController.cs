using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ContentController.instance.AddItem(item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ContentController.instance.DeleteItem(item);
    }

}