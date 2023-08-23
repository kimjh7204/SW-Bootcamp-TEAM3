using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForDecomposition : MonoBehaviour, IPointerClickHandler
{
    public InvetoryManager0 inventoryManager;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount >= 2)
        {
            if (inventoryManager.showedItem == null) return;
            DecompositionItem(inventoryManager.showedItem);
        }


    }

    private void DecompositionItem(Item item)
    {
        if (item.decomposition == null) return;
        
        if(inventoryManager.IsInventoryFUll())
        {
            inventoryManager.NoticeInventoryFull();
        }
        else
        {
            // item 삭제
            Destroy(inventoryManager.showedItemUI.gameObject);
            Destroy(inventoryManager.showedObject);
            // item 분해 후 아이템 두개 생성
            if (inventoryManager.showedItem.decomposition.decompositionItem1 != null)
                inventoryManager.SetItem(inventoryManager.showedItem.decomposition.decompositionItem1);
            if (inventoryManager.showedItem.decomposition.decompositionItem2 != null)
                inventoryManager.SetItem(inventoryManager.showedItem.decomposition.decompositionItem2);

            inventoryManager.showedItem = null;

        }

    }




}
