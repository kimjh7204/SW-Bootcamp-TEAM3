using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ContentController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject[] slots = new GameObject[5];
    public GameObject[] itemGameObjects = new GameObject[5];

    public static ContentController instance;
    public GameObject content;

    public GameObject player;


    private void Start()
    {
        instance = this;
        content.SetActive(false);
    }

    private void Update()
    {
        this.gameObject.transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(20, -10, 0));
        // 미니창 위치 설정
    }

    public void AddItem(Item item, GameObject gameObject)
    {
        // 미니창 슬롯에 아이템을 추가하는 함수.
        // 빈 슬롯을 찾아 해당 슬롯에 아이템 정보를 넣는다.

        content.SetActive(true);

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<SlotController>().item == null)
            {
                slots[i].GetComponent<SlotController>().item = item;
                itemGameObjects[i] = gameObject;
                break;
            }
        }

        
    }

    public void DeleteItem(Item item)
    {
        // 미니창 슬롯에서 아이템을 제거하는 함수.
        // 주어진 아이템을 슬롯에서 찾아서 해당 아이템 정보를 삭제한다.

        for (int i = 0; i < slots.Length; i++)
        {

            if (slots[i].GetComponent<SlotController>().item == item)
            {
                slots[i].GetComponent<SlotController>().item = null;
                itemGameObjects[i] = null;
                CleanItem();
                SetContent();
                break;
            }
        }
    }

    private void CleanItem()
    {
        // 미니창 슬롯 정리하는 함수.
        // 슬롯에서 빈칸 다음에 아이템이 있으면 한칸 앞으로 옮긴다.

        Item currentItem;
        Item nextItem;
        for (int i = 0; i < slots.Length - 1; i++)
        {
            currentItem = slots[i].GetComponent<SlotController>().item;
            nextItem = slots[i + 1].GetComponent<SlotController>().item;

            if (currentItem == null && nextItem != null)
            {
                currentItem = nextItem;
                nextItem = null;
            }
        }
    }

    private void SetContent()
    {
        // 미니창을 계속 보여줄지 안보여줄지 설정하는 함수.
        // 미니창 슬롯에 아무것도 없으면 미니창을 닫는다.

        if (slots[0].GetComponent<SlotController>().item == null)
        {
            content.SetActive(false);

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    { // 미니창 슬롯 범위를 클릭했을 때 플레이어가 의도치 않게 움직이는 것을 막기 위함.
        NavData.playerCanMove = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    { // 미니창 슬롯 범위를 클릭했을 때 플레이어가 의도치 않게 움직이는 것을 막기 위함.
        NavData.playerCanMove = false;

    }
}