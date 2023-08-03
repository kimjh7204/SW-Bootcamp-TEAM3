using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public Item item = null;

    private void Start()
    {
        //textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();  //나중에 이미지, 네임 이걸로 컴포넌트 변경.
    }
    void Update()
    {
        if (item == null)
        {
            
            this.gameObject.SetActive(false);
            //this.itemImage.color = new Color(1, 1, 1, 0);
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