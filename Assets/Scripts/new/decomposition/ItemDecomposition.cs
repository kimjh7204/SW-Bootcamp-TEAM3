using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDecomposition : ScriptableObject
{
    [Header("분해 후 생성되는 아이템")]
    public Item decompositionItem1;
    public Item decompositionItem2;
}
