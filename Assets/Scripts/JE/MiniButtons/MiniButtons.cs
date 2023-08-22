using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
//using static UnityEditor.Progress;

public class MiniButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ItemUI0 itemUI; // 내가 우클릭한 현재 ItemUI
    public TextMeshProUGUI useOReatText;
    public Transform player;
    public InvetoryManager0 inventoryManager;
    private Dictionary<Item.ItemTag2, int> percentages = new Dictionary<Item.ItemTag2, int>()
    {  // UseItem() 했을 때 사용이 안되는 확률
        {Item.ItemTag2.none, 100},
        {Item.ItemTag2.ax, 50},
        {Item.ItemTag2.raft1, 0},
        {Item.ItemTag2.raft2, 0},
        {Item.ItemTag2.raft3, 0},
        {Item.ItemTag2.fishing, 0},
        {Item.ItemTag2.light, 0}
    };


    [Header("사용하기 버튼을 통해 생성할 필요가 있는 것들")]
    public Item coconut;
    private Vector3 pos;

    [Header("뗏목 사용시 띄울 패널")]
    public GameObject raftPanel;

    [Header("낚시 패널")]
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
    // 버튼 기능들

    public void InstallButtonClick()
    {
        // 아이템이 장착되고(InstallState에 아이템 정보 전달)
        // 장착한 아이템은 인벤토리에 남아있는가*****
        if(this.itemUI != null)
        {
            InstallState.instance.InstallItem(itemUI.itemData);  //InstallState에 아이템 정보 전달
        }
        

    }
   
    public void UseOrEatButtonClick()
    {
        // 아이템을 사용하거나 먹은 효과가 나타나고
        // 아이템 개수가 하나 줄어든다

        // 현재 슬롯인 itemUI의 itemData의 itemTag가 food 이면 eat 실행
        // 아니면 use 실행
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
        else if(itemUI.itemData.itemTag2 == Item.ItemTag2.bottle)
        {
            // 물병에 물 채우기
            UseBottle(itemUI);
        }
        else if(itemUI.itemData.itemTag2 == Item.ItemTag2.fireFood)
        {
            // 음식 굽기
            GrillFoodOnFire(itemUI);

        }
        else if(itemUI.itemData.itemTag2 == Item.ItemTag2.light)
        {
            PlayerLightController.instance.LightUse();
            PlayerLightController.itemUI = itemUI;
        }
        else if(itemUI.itemData.itemTag2 == Item.ItemTag2.fireMaker)
        {
            UseFireMaker();
        }
        else if(GameData.playerCollisionState == "ocean" && itemUI.itemData.itemTag2 == Item.ItemTag2.raft3)
        {
            EndingObjectMove.instance.ShowEnding();
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
        // 플레이어 position 앞쪽 위치에 현재 슬롯인 itemUI의 itemData의 itemGameObject를 생성
        // 해당 아이템 삭제

        var newItem = Instantiate<GameObject>(itemUI.itemData.itemGameObject, player.position, Quaternion.identity);
        newItem.transform.SetParent(player.transform);
        newItem.transform.localPosition = new Vector3(0, 0, 1.5f);
        newItem.transform.SetParent(player.transform.parent);
        newItem.transform.position += new Vector3(0, 3f, 0);


        itemUI.DeleteUI();

        //InstallState.instance.CheckInstallItem(itemUI.itemData);

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

        if (Random.Range(0, 100) < percentages[item.itemTag2]) return;  // 확률

        if (item.itemTag2 == Item.ItemTag2.ax && GameData.playerCollisionState == "tree")
        {   // 나무 구역에서 (tree zone)
            // 도끼 사용 -> 코코넛 생성
            // use ax -> create coconut
            pos = new Vector3(player.position.x + 1f, player.position.y + 2f, player.position.z);
            var coco = Instantiate<GameObject>(coconut.itemGameObject, pos, Quaternion.identity);
        }
        else if(GameData.playerCollisionState == "ocean")
        {   
            if(item.itemTag2 == Item.ItemTag2.raft1 || item.itemTag2 == Item.ItemTag2.raft2 || item.itemTag2 == Item.ItemTag2.raft3)
            {   // 바다 구역에서 (ocean zone)
                // 뗏목1 사용 -> 패널 띄우기
                // use raft1 -> show panel
                raftPanel.SetActive(true);  // 이후 과정은 패널에서 처리
                GameData.useWhatOnOseanZone = item;  // 정보 넣어주기
            }  
        }
        else if (GameData.playerCollisionState == "fishingWater")
        {   
            if(item.itemTag2 == Item.ItemTag2.fishing)
            {   // 낚시&물 구역에서 (fishingWater zone)
                // 낚시도구 사용 -> 물고기 잡았다는 패널 띄우기
                // use fishing tool -> show fishingPanel
                fishingPanel.SetActive(true);
            }
        }
        


    }

    private void UseFireMaker()
    {
        if (GameData.playerCollisionState != "fire") return;
        FireController.instance.SetFire();
    }


    private void GrillFoodOnFire(ItemUI0 itemUI)
    {
       if (GameData.playerCollisionState == "fire" && FireController.isFireOn)
        {   // 불 구역에서 (fire zone)
            // 음식 사용 -> 불에 구운 후의 아이템 생성
            // use food -> create item after fire
            if (inventoryManager.IsInventoryFUll())
            {
                inventoryManager.NoticeInventoryFull();
                return;
            }

            itemUI.DeleteUI();
            inventoryManager.SetItem(itemUI.itemData.itemAfterOnFire);

        }
                

    }

    private void UseBottle(ItemUI0 itemUI)
    {
        if (GameData.playerCollisionState == "fishingWater")
        {   // 낚시&물 구역에서 (fishingWater zone)
            // 물병 사용 -> 물통에 물 채우기(물병 삭제, 물있는물병 생성)
            // use bottle -> bottle with water
            if(inventoryManager.IsInventoryFUll())
            {
                inventoryManager.NoticeInventoryFull();
            }
            else
            {
                itemUI.DeleteUI();  // 기존 empty bottle 삭제
                inventoryManager.SetItem(itemUI.itemData.bottleWithWater);  // bottle with water 인벤토리에 추가
            }

            
        }
    }



    private void DeleteShowed()
    {
        Destroy(inventoryManager.showedObject);
        inventoryManager.tooltipText.text = null;
    }
}
