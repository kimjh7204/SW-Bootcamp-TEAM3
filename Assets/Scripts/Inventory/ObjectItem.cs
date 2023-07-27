using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectItem : MonoBehaviour,Addable
{
    [Header("아이템")]
    public Item item;
//  [Header("아이템 이미지")]
//  public Sprite itemImage;
 //   [Header("아이템 오브젝트")]
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
