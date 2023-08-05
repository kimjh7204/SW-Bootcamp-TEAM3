using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ItemUI0 itemUI; // 내가 우클릭한 현재 ItemUI
    public TextMeshProUGUI useOReatText;
    public void SetItemUI(ItemUI0 itemui)
    {
        itemUI = itemui;
        // 비교가 안됨*********
        /*if (itemUI.itemData.itemTag.Equals("food"))
        {
            useOReatText.text = "eat";
        }
        else
        {
            useOReatText.text = "use";
        }*/
        //Debug.Log(itemUI.itemData.itemTag);
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
            InstallState.instance.InstallItem(itemUI.itemData);
        }
        

    }
   
    public void UseOrEatButtonClick()
    {
        // 아이템을 사용하거나 먹은 효과가 나타나고
        // 아이템 개수가 하나 줄어든다

    }

    public void ThrowButtonClick()
    {
        // 플레이어가 있는 자리에 아이템 오브젝트를 생성하고
        // 아이템 개수가 하나 줄어든다
    }
}
