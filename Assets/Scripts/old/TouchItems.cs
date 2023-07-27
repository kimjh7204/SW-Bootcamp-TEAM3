using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchItems : MonoBehaviour
{
    [Header("인벤토리")]
    public Inventory inventory;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, 10000f, 1<<3);

            if (hit.collider != null) HitCheckObject(hit);
            
        }
    }


    void HitCheckObject(RaycastHit hit)
    {
        ObjectItem clickInterface = hit.transform.gameObject.GetComponent<ObjectItem>();
        Destroy(hit.transform.gameObject, 0.1f);
        //hit.transform.gameObject.GetComponent<ObjectItem>()

        if (clickInterface != null)
        {
            Item item = clickInterface.ClickItem();
            print($"{item.itemName}");
            inventory.AddItem(item);

        }
    }
}
