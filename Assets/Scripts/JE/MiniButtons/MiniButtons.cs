using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ItemUI0 itemUI; // 내가 우클릭한 현재 ItemUI
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
            eatItem(itemUI.itemData);
        }
        else
        {
            useItem(itemUI.itemData);
        }

        itemUI.itemData.amount -= 1;

        itemUI.AmountCheck();  // amount가 0개 이하면 슬롯 삭제
    }

    public void ThrowButtonClick()
    {
        // 플레이어가 있는 자리에 아이템 오브젝트를 생성하고
        // 아이템 개수가 하나 줄어든다

        // 플레이어 position 앞쪽 위치에 현재 슬롯인 itemUI의 itemData의 itemGameObject를 생성
        // 해당 아이템 amount를 하나 줄인다.
        // 아이템이 0개면 슬롯 삭제

        var newItem = Instantiate<GameObject>(itemUI.itemData.itemGameObject, player.position, Quaternion.identity);
        newItem.transform.SetParent(player.transform);
        newItem.transform.localPosition = new Vector3(0, 0, 1.5f);
        newItem.transform.SetParent(player.transform.parent);
        newItem.transform.position += new Vector3(0, itemUI.itemData.positionY, 0);

        itemUI.itemData.amount -= 1;

        itemUI.AmountCheck();  // amount가 0개 이하면 슬롯 삭제

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
