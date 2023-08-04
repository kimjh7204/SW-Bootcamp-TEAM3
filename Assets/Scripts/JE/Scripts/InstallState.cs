using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstallState : MonoBehaviour
{
    public static InstallState instance;
    private Item installITem;

    [Header("장착 아이템 표시 이미지")]
    public Image installItemImage;

    void Start()
    {
        instance = this;
    }

    public void InstallItem(Item item)
    {
        installITem = item;
        installItemImage.sprite = installITem.itemImage;
    }

}
