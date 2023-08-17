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
            if(_item != null)
                this.gameObject.SetActive(true);


        }
    }

    public int slotIndex;  // 화면에서 보이는 슬롯 순서(0부터)

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
            itemName.text = null;
            itemImage.sprite = null;
            itemTooltip = null;
            this.gameObject.SetActive(false);

        }
        else
        {
            this.gameObject.SetActive(true);
            itemImage.sprite = item.itemImage;
            itemName.text = item.itemName;
            itemTooltip.text = item.itemTooltip;

        }
    }
}