using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPosition : MonoBehaviour
{
    public Transform player;
    public GameObject testItem;
    private Vector3 itemPosition;

    void Start()
    {
        //itemPosition = new Vector3(player.position.x, player.position.y + 0.42f, player.position.z + 3f);
        var newItem = Instantiate<GameObject>(testItem, player.position, Quaternion.identity);
        newItem.transform.SetParent(player.transform);
        newItem.transform.localPosition = new Vector3(0, 0, 1.5f);
        newItem.transform.SetParent(player.transform.parent);
    }

}
