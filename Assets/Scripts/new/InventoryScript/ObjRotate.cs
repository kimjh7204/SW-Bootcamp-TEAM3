using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjRotate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler
{
    // 3D 오브젝트 회전시키는 것

    [Header("3D 오브젝트 회전 속도")]
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
        //if (inventoryManager.showedObject == null) return;
        offset = (-Input.mousePosition + mousePos);
        float x = eventData.delta.x * Time.deltaTime * rotateSpeed;
        float y = eventData.delta.y * Time.deltaTime * rotateSpeed;
        inventoryManager.showedObject.transform.Rotate(y, -x, 0, Space.World);
        
        mousePos = Input.mousePosition;
    }

    

    

}
