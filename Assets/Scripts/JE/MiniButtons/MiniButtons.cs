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
    public InvetoryManager0 inventoryManager;
    


    [Header("����ϱ� ��ư�� ���� ������ �ʿ䰡 �ִ� �͵�")]
    public Item coconut;
    private Vector3 pos;


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
            itemUI.AmountCheck();
        }
        else
        {
            useItem(itemUI.itemData);
        }

        //itemUI.itemData.amount -= 1;



        this.gameObject.SetActive(false);
        DeleteShowed();
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
        newItem.transform.position += new Vector3(0, 3f, 0);

        //itemUI.itemData.amount -= 1;

        itemUI.AmountCheck();  // amount�� 0�� ���ϸ� ���� ����

        InstallState.instance.CheckInstallItem(itemUI.itemData);

        this.gameObject.SetActive(false);
        DeleteShowed();




    }

    private void eatItem(Item item)
    {
        // item eat
        StateBar1.instance.EatFull(item.eatStateFull);    
    }

    private void useItem(Item item)
    {
        // item use
        //Debug.Log(item.itemName + GameData.playerCollisionState);

        if(item.itemName == "ax" && GameData.playerCollisionState == "tree")
        {
            // ���ڳ� ����
            pos = new Vector3(player.position.x + 1f, player.position.y + 2f, player.position.z);
            var coco = Instantiate<GameObject>(coconut.itemGameObject, pos, Quaternion.identity);
            
        }






    }

    private void DeleteShowed()
    {
        Destroy(inventoryManager.showedObject);
        inventoryManager.tooltipText.text = null;
    }
}
