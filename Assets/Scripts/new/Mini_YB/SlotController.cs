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

    void Update()
    {
        if (item == null)
        {
            this.gameObject.SetActive(false);
            this.itemImage.color = new Color(1, 1, 1, 0);
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