using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [Header("������ �̸�")]
    public string itemName;

    [Header("������ �̹���")]
    public Sprite itemImage;

    [Header("������ ����")]
    public string itemTooltip;

    [Header("���ӿ�����Ʈ")]
    public GameObject itemGameObject;

    [Header("�����ϰ� �ִ� ����")]
    public int amount;

    
    

    public enum ItemTag
    {
        food,
        tool
    }
    [Header("������ �±�(���� �� ������ food)")]
    public ItemTag itemTag;

    [Header("���� �� �ִ� ��� ��ҷ����� ����")]
    public float eatStateFull;



}
