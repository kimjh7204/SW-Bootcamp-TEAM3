using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class itemCombination : ScriptableObject
{
    //[Header("원본 아이템")]
    //public Item originItem;

    [Header("합친 아이템")]
    public Item inputItem;

    [Header("결과 아이템")]
    public Item resultItem;
}
