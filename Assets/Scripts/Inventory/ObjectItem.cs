using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectItem : MonoBehaviour,Addable
{
    [Header("������")]
    public Item item;
//  [Header("������ �̹���")]
//  public Sprite itemImage;
 //   [Header("������ ������Ʈ")]
 //   private MeshFilter itemObj;

    void Start()
    {
//      item.itemImage = itemImage;
    }
    public Item ClickItem()
    {
        return this.item;
    }
    
}
