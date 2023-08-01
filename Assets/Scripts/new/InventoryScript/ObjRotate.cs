using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjRotate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler
{
    // 3D 오브젝트 회전시키는 것

    [Header("3D 오브젝트 회전 속도")]
    public float rotateSpeed = 30f;
    Vector3 mousePos, offset, rotation;
    private bool isPointerEnter = false;
    private bool isDrag = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }



    void Update()
    {
        if (Input.GetMouseButton(0) && isPointerEnter && isDrag)
        {
            offset = (-Input.mousePosition + mousePos);
            rotation.x = offset.y * Time.deltaTime * rotateSpeed;
            rotation.y = offset.x * Time.deltaTime * rotateSpeed;
            GameData.objectShowed.transform.Rotate(rotation, Space.World);
        }
        mousePos = Input.mousePosition;


    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerEnter = false;
        isDrag = false;
    }
}
