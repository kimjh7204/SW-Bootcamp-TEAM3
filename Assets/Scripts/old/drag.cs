using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    Vector3 clickPoint;
    float upDownSpeed = 5.0f;
    private Item itemObj;
    private GameObject spwanObejct;

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
