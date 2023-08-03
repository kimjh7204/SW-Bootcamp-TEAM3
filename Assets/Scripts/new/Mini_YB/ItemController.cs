using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{
    public Item item;
    //private ContentController instance; // ���߿� ����.

    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("�ݸ��� �߻�");
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