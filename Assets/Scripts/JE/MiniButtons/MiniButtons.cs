using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ItemUI0 itemUI; // ���� ��Ŭ���� ���� ItemUI
    public TextMeshProUGUI useOReatText;
    public void SetItemUI(ItemUI0 itemui)
    {
        itemUI = itemui;
        // �񱳰� �ȵ�*********
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
    // ��ư ��ɵ�

    public void InstallButtonClick()
    {
        // �������� �����ǰ�(InstallState�� ������ ���� ����)
        // ������ �������� �κ��丮�� �����ִ°�*****
        if(this.itemUI != null)
        {
            InstallState.instance.InstallItem(itemUI.itemData);
        }
        

    }
   
    public void UseOrEatButtonClick()
    {
        // �������� ����ϰų� ���� ȿ���� ��Ÿ����
        // ������ ������ �ϳ� �پ���

    }

    public void ThrowButtonClick()
    {
        // �÷��̾ �ִ� �ڸ��� ������ ������Ʈ�� �����ϰ�
        // ������ ������ �ϳ� �پ���
    }
}
