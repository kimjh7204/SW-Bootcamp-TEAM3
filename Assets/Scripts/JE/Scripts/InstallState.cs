using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstallState : MonoBehaviour
{
    public static InstallState instance;
    private Item installITem;

    [Header("���� ������ ǥ�� �̹���")]
    public Image installItemImage;

    void Start()
    {
        instance = this;
        if(installITem == null)
        {
            installItemImage.gameObject.SetActive(false);
        }
    }

    public void InstallItem(Item item)
    {
        installITem = item;
        installItemImage.sprite = installITem.itemImage;
        installItemImage.gameObject.SetActive(true);
    }

}
