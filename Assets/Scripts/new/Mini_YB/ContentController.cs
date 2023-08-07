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
        // �̴�â ��ġ ����
    }

    public void AddItem(Item item, GameObject gameObject)
    {
        // �̴�â ���Կ� �������� �߰��ϴ� �Լ�.
        // �� ������ ã�� �ش� ���Կ� ������ ������ �ִ´�.

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
        // �̴�â ���Կ��� �������� �����ϴ� �Լ�.
        // �־��� �������� ���Կ��� ã�Ƽ� �ش� ������ ������ �����Ѵ�.

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
        // �̴�â ���� �����ϴ� �Լ�.
        // ���Կ��� ��ĭ ������ �������� ������ ��ĭ ������ �ű��.

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
        // �̴�â�� ��� �������� �Ⱥ������� �����ϴ� �Լ�.
        // �̴�â ���Կ� �ƹ��͵� ������ �̴�â�� �ݴ´�.

        if (slots[0].GetComponent<SlotController>().item == null)
        {
            content.SetActive(false);

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    { // �̴�â ���� ������ Ŭ������ �� �÷��̾ �ǵ�ġ �ʰ� �����̴� ���� ���� ����.
        NavData.playerCanMove = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    { // �̴�â ���� ������ Ŭ������ �� �÷��̾ �ǵ�ġ �ʰ� �����̴� ���� ���� ����.
        NavData.playerCanMove = false;

    }
}