using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ItemUI0 itemUI; // ���� ��Ŭ���� ���� ItemUI
    public TextMeshProUGUI useOReatText;
    public Transform player;
    public void SetItemUI(ItemUI0 itemui)
    {
        itemUI = itemui;
        
        if(itemUI.itemData.itemTag == Item.ItemTag.food)
        {
            useOReatText.text = "eat";
        }
        else
        {
            useOReatText.text = "use";
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);

    }


    void Start()
    {
        this.gameObject.SetActive(false);
    }


    //------------------------------
    // ��ư ��ɵ�

    public void InstallButtonClick()
    {
        // �������� �����ǰ�(InstallState�� ������ ���� ����)
        // ������ �������� �κ��丮�� �����ִ°�*****
        if(this.itemUI != null)
        {
            InstallState.instance.InstallItem(itemUI.itemData);  //InstallState�� ������ ���� ����
        }
        

    }
   
    public void UseOrEatButtonClick()
    {
        // �������� ����ϰų� ���� ȿ���� ��Ÿ����
        // ������ ������ �ϳ� �پ���

        // ���� ������ itemUI�� itemData�� itemTag�� food �̸� eat ����
        // �ƴϸ� use ����
        if(itemUI.itemData.itemTag == Item.ItemTag.food)
        {
            eatItem(itemUI.itemData);
        }
        else
        {
            useItem(itemUI.itemData);
        }

        itemUI.itemData.amount -= 1;

        itemUI.AmountCheck();  // amount�� 0�� ���ϸ� ���� ����
    }

    public void ThrowButtonClick()
    {
        // �÷��̾ �ִ� �ڸ��� ������ ������Ʈ�� �����ϰ�
        // ������ ������ �ϳ� �پ���

        // �÷��̾� position ���� ��ġ�� ���� ������ itemUI�� itemData�� itemGameObject�� ����
        // �ش� ������ amount�� �ϳ� ���δ�.
        // �������� 0���� ���� ����

        var newItem = Instantiate<GameObject>(itemUI.itemData.itemGameObject, player.position, Quaternion.identity);
        newItem.transform.SetParent(player.transform);
        newItem.transform.localPosition = new Vector3(0, 0, 1.5f);
        newItem.transform.SetParent(player.transform.parent);
        newItem.transform.position += new Vector3(0, itemUI.itemData.positionY, 0);

        itemUI.itemData.amount -= 1;

        itemUI.AmountCheck();  // amount�� 0�� ���ϸ� ���� ����

    }

    private void eatItem(Item item)
    {
        // item eat
    }

    private void useItem(Item item)
    {
        // item use
    }
}
