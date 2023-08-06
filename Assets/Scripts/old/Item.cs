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

    [Header("아이템 게임오브젝트(프리팹)")]
    public GameObject itemGameObject;

    [Header("아이템 개수")]
    public int amount;

    [Header("아이템이 바닥에 딱 붙는 Y값(아이템 생성시킬 때)")]
    public float positionY;


    public enum ItemTag
    { 
        item,
        food,
        tool
    }
    [Header("아이템 태그(먹을 수 있으면 food)")]
    public ItemTag itemTag;

    [Header("먹었을 때 배고픔 줄어드는 정도")]
    public float eatStateFull;



}
