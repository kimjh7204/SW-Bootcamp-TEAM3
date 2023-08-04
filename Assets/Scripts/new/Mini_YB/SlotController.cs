using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotController : MonoBehaviour, IPointerClickHandler
{
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public Item item = null;
    public InvetoryManager0 inventoryManager;

    public int slotIndex;  // 

    public void OnPointerClick(PointerEventData eventData)
    {
        inventoryManager.SetItem(item);
        Destroy(ContentController.instance.itemGameObjects[slotIndex]);
        ContentController.instance.DeleteItem(item);
    }

    private void Start()
    {
        //textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();  //나중에 이미지, 네임 이걸로 컴포넌트 변경.
    }
    void Update()
    {
        if (item == null)
        {
            
            this.gameObject.SetActive(false);
            itemName.text = null;
            itemImage.sprite = null;
        }
        else
        {
            this.gameObject.SetActive(true);

            itemImage.sprite = item.itemImage;
            itemName.text = item.itemName;
        }
    }
}