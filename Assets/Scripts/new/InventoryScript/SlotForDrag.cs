using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotForDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // 슬롯 드래그하면 이미지가 마우스 따라가게 하고
    // 이상한 곳에서 드래그가 끝났을 때 제자리로 돌아가게 함.

    private Vector2 startPos;
    private Transform parent;
    public TextMeshProUGUI numberText;



    private void Start()
    {
        parent = this.transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position;
        GameData.droppedObejct = this.gameObject;
        this.transform.SetParent(parent.parent.parent.parent);
        this.GetComponent<Image>().raycastTarget = false;
        numberText.transform.SetParent(parent.parent.parent.parent);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
        this.transform.position = startPos;
        this.transform.SetParent(parent);
        this.GetComponent<Image>().raycastTarget = true;
        numberText.transform.SetParent(parent);
    }
}
