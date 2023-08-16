using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjRotate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IPointerUpHandler
{
    // 3D ������Ʈ ȸ����Ű�� ��

    [Header("3D ������Ʈ ȸ�� �ӵ�")]
    public float rotateSpeed = 30f;
    Vector3 mousePos, offset, rotation;
    private bool isPointerEnter = false;
    //private bool isDrag = false;

    public InvetoryManager0 inventoryManager;

    public void OnBeginDrag(PointerEventData eventData)
    {
    }



    void Update()
    {
        


    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerEnter = true;
        inventoryManager.isOnObjRotate = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerEnter = false;
        inventoryManager.isOnObjRotate = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        //if (Input.GetMouseButton(0) && isPointerEnter)
        //{
            offset = (-Input.mousePosition + mousePos);
            float x = eventData.delta.x * Time.deltaTime * rotateSpeed;
            float y = eventData.delta.y * Time.deltaTime * rotateSpeed;
        inventoryManager.showedObject.transform.Rotate(y, -x, 0, Space.World);
        //}
        mousePos = Input.mousePosition;
    }

    //-------------------------------

    public void OnPointerUp(PointerEventData eventData)
    {
        if (inventoryManager.draggingItem == null) return;
        for (int i = 0; i < inventoryManager.showedItem.combination.Length; i++) 
        {
            if (inventoryManager.showedItem.combination[i].inputItem == inventoryManager.draggingItem)
            {
                // �ΰ� ���ְ�
                // resultITem ����
                inventoryManager.SetItem(inventoryManager.showedItem.combination[i].resultItem);
            }
        }
    }

    

}
