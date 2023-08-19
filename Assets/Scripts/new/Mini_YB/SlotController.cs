using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotController : MonoBehaviour, IPointerClickHandler
{
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemTooltip;
    public Item _item = null;
    public InvetoryManager0 inventoryManager;

    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                itemName.text = null;
                itemImage.sprite = null;
                itemTooltip.text = null;
                this.gameObject.SetActive(false);

            }
            else
            {
                itemImage.sprite = item.itemImage;
                itemName.text = item.itemName;
                itemTooltip.text = item.itemTooltip;
                this.gameObject.SetActive(true);
            }


        }
    }

    public int slotIndex;  // 화면에서 보이는 슬롯 순서(0부터)

    public void OnPointerClick(PointerEventData eventData)
    {
        if(inventoryManager.IsInventoryFUll())
        {
            inventoryManager.NoticeInventoryFull();
        }
        else
        {
            inventoryManager.SetItem(item);
            Destroy(ContentController.instance.itemGameObjects[slotIndex]);
            ContentController.instance.DeleteItem(item);
        }

        
    }

    private void Start()
    {
    }

    private void Update()
    {
        if(item == null)
        {
            this.gameObject.SetActive(false);
        }
        
    }
}