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
            DecompositionItem(inventoryManager.showedItem);
        }


    }

    private void DecompositionItem(Item item)
    {
        if (item.decomposition == null) return;

        // item 삭제
        Destroy(inventoryManager.showedItemUI.gameObject);
        Destroy(inventoryManager.showedObject);
        // item 분해 후 아이템 두개 생성
        inventoryManager.SetItem(inventoryManager.showedItem.decomposition.decompositionItem1);
        inventoryManager.SetItem(inventoryManager.showedItem.decomposition.decompositionItem2);

        inventoryManager.showedItem = null;
        
    }




}
