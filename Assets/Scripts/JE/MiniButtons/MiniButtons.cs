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
    private Dictionary<Item.ItemTag2, int> percentages = new Dictionary<Item.ItemTag2, int>()
    {  // UseItem() ���� �� ����� �ȵǴ� Ȯ��
        {Item.ItemTag2.none, 100},
        {Item.ItemTag2.ax, 50},
        {Item.ItemTag2.raft1, 0},
        {Item.ItemTag2.raft2, 0},
        {Item.ItemTag2.raft3, 0},
        {Item.ItemTag2.fishing, 0}
    };


    [Header("����ϱ� ��ư�� ���� ������ �ʿ䰡 �ִ� �͵�")]
    public Item coconut;
    private Vector3 pos;

    [Header("�¸� ���� ��� �г�")]
    public GameObject raftPanel;

    [Header("���� �г�")]
    public GameObject fishingPanel;

    public void SetItemUI(ItemUI0 itemui)
    {
        itemUI = itemui;
        
        if(itemUI.itemData.itemTag == Item.ItemTag.food || itemUI.itemData.itemTag == Item.ItemTag.water)
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

        raftPanel.SetActive(false);
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
            EatItem(itemUI.itemData);
            itemUI.DeleteUI();
        }
        else if(itemUI.itemData.itemTag == Item.ItemTag.water)
        {
            DrinkItem(itemUI.itemData);
            itemUI.DeleteUI();
        }
        else
        {
            UseItem(itemUI.itemData);
        }



        this.gameObject.SetActive(false);
        DeleteShowed();
    }

    public void ThrowButtonClick()
    {
        // �÷��̾� position ���� ��ġ�� ���� ������ itemUI�� itemData�� itemGameObject�� ����
        // �ش� ������ ����

        var newItem = Instantiate<GameObject>(itemUI.itemData.itemGameObject, player.position, Quaternion.identity);
        newItem.transform.SetParent(player.transform);
        newItem.transform.localPosition = new Vector3(0, 0, 1.5f);
        newItem.transform.SetParent(player.transform.parent);
        newItem.transform.position += new Vector3(0, 3f, 0);


        itemUI.DeleteUI();

        InstallState.instance.CheckInstallItem(itemUI.itemData);

        this.gameObject.SetActive(false);
        DeleteShowed();




    }

    private void EatItem(Item item)
    {
        // item eat
        StateBar1.instance.EatFull(item.eatStateFull);    
    }

    private void DrinkItem(Item item)
    {
        StateBar2.instance.Drink(item.thirstStateFull);
    }

    private void UseItem(Item item)
    {
        // item use
        //Debug.Log(item.itemName + GameData.playerCollisionState);

        if (Random.Range(0, 100) < percentages[item.itemTag2]) return;  // Ȯ��

        if (item.itemTag2 == Item.ItemTag2.ax && GameData.playerCollisionState == "tree")
        {   // ���� �������� (tree zone)
            // ���� ��� -> ���ڳ� ����
            // use ax -> create coconut
            pos = new Vector3(player.position.x + 1f, player.position.y + 2f, player.position.z);
            var coco = Instantiate<GameObject>(coconut.itemGameObject, pos, Quaternion.identity);
        }
        else if(GameData.playerCollisionState == "ocean")
        {   
            if(item.itemTag2 == Item.ItemTag2.raft1 || item.itemTag2 == Item.ItemTag2.raft2 || item.itemTag2 == Item.ItemTag2.raft3)
            {   // �ٴ� �������� (ocean zone)
                // �¸�1 ��� -> �г� ����
                // use raft1 -> show panel
                raftPanel.SetActive(true);  // ���� ������ �гο��� ó��
                GameData.useWhatOnOseanZone = item;  // ���� �־��ֱ�
            }  
        }
        if (item.itemTag2 == Item.ItemTag2.fishing && GameData.playerCollisionState == "fishing")
        {   // ���� �������� (fishing zone)
            // ���õ��� ��� -> ����� ��Ҵٴ� �г� ����
            // use fishing tool -> show fishingPanel
            fishingPanel.SetActive(true);
        }








    }

    private void DeleteShowed()
    {
        Destroy(inventoryManager.showedObject);
        inventoryManager.tooltipText.text = null;
    }
}
