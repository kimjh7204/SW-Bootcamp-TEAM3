using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class PlayerItemController : MonoBehaviour
{

    private void OnTriggerEnter(Collider item)
    {
        if (item.CompareTag("Item"))
        {
            ContentController.instance.AddItem(item.GetComponent<ItemController>().item, item.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            ContentController.instance.DeleteItem(other.GetComponent<ItemController>().item);
        }
        
    }

}