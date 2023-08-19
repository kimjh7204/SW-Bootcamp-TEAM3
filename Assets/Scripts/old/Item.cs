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

    [Header("미니탭에 띄우는 짧은 설명")]
    public string itemShortTooltip;

    [Header("아이템 게임오브젝트(프리팹)")]
    public GameObject itemGameObject;

    [Header("인벤토리에서 3D OBJ로 보여줄 오브젝트(프리팹)")]
    public GameObject itemShowObject;

    public enum ItemTag
    { 
        item,
        food,
        water,
        tool
    }
    [Header("아이템 태그(먹을 수 있으면 food)")]
    public ItemTag itemTag;

    public enum ItemTag2
    {
        none,
        ax,
        raft1,
        raft2,
        raft3,
        fishing,
        bottle,
        fireFood
    }
    [Header("아이템 태그2(아이템 사용을 위한 태그임)")]
    public ItemTag2 itemTag2;


    [Header("먹었을 때 배고픔 줄어드는 정도")]
    public float eatStateFull;

    [Header("먹었을 때 갈증 줄어드는 정도")]
    public float thirstStateFull;

    [Header("아이템 조합들")]
    public itemCombination[] combination;

    [Header("분해 목록(이 아이템을 분해할 때)")]
    public ItemDecomposition decomposition;

    [Header("itemTag2가 bottle인 경우 : 물이 든 물병(Item)")]
    public Item bottleWithWater;

    [Header("itemTag2가 fireFood인 경우 : 불에 구운 후의 Item")]
    public Item itemAfterOnFire;
}
