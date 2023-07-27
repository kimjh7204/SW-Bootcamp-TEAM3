using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Vector3 clickPoint;
    float upDownSpeed = 5.0f;
    private Item itemObj;
    private GameObject spwanObejct;
    private Vector3 DefaultPos;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
        //Instantiate();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;


    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = DefaultPos;
        var hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit)
        {
            if (hit.collider.gameObject.name == this.name)
            {
                // 할 것
            }
        }

    }
    /*

    //인벤토리 슬롯 드래그 해서 합치기
    //

    //해당 슬롯 오브젝트를 인스턴스화해서 정해진 위치에 생성 
    //+ 시간되면 클릭시 인스턴스 오브젝트 마우스 위치에 생성
    //드래그 해서 콜라이더랑 충돌 날 경우
    //정해진 위치에 오브젝트 인스턴스 생성


    //


*/
    /*if (Input.GetMouseButtonDown(0) && Input.mousePosition.y >900)
    {
        var wPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(wPos, Vector2.zero);
        if (hit)
        {
            if (hit.collider.gameObject.name == this.name)
            {
                // 할 것
            }
        }
    }*/
    

    private void Start()
    {

    }
    void OnMouseDown()
    {
        clickPoint = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        Vector3 diff = Input.mousePosition - clickPoint;
        Vector3 pos = transform.position;

        pos.y += diff.y * Time.deltaTime * upDownSpeed;
        transform.position = pos;

        clickPoint = Input.mousePosition;
    }
    /*
    private void ObjectMove()
    {
        // Screen 좌표계인 mousePosition을 World 좌표계로 바꾼다
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //오브젝트 생성
        spwanObejct = Instantiate(itemObj, new Vector3(mousePos.x, 0, mousePos.z), Quaternion.identity);

        // 오브젝트는 x로만 움직여야 하기 때문에 y는 고정
        mousePos.y = spwanObject.transform.position.y;

        spwanObject.transform.position = mousePos;
    }*/

    /*void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

        //objPos.z = 0;
        objPos.y = 0;
        transform.position = objPos;
    }*/
}
