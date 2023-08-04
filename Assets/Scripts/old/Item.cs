using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [Header("아이템 이름")]
    public string itemName;

    [Header("아이템 이미지")]
    public Sprite itemImage;

    [Header("아이템 설명")]
    public string itemTooltip;

    [Header("게임오브젝트")]
    public GameObject itemGameObject;

    [Header("보유하고 있는 수량")]
    public int amount;

    
    

    public enum ItemTag
    {
        food,
        tool
    }
    [Header("아이템 태그(먹을 수 있으면 food)")]
    public ItemTag itemTag;

    [Header("먹을 수 있는 경우 배불러지는 정도")]
    public float eatStateFull;



}
