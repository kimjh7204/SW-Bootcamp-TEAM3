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
                // �� ��
            }
        }

    }
    /*

    //�κ��丮 ���� �巡�� �ؼ� ��ġ��
    //

    //�ش� ���� ������Ʈ�� �ν��Ͻ�ȭ�ؼ� ������ ��ġ�� ���� 
    //+ �ð��Ǹ� Ŭ���� �ν��Ͻ� ������Ʈ ���콺 ��ġ�� ����
    //�巡�� �ؼ� �ݶ��̴��� �浹 �� ���
    //������ ��ġ�� ������Ʈ �ν��Ͻ� ����


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
                // �� ��
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
        // Screen ��ǥ���� mousePosition�� World ��ǥ��� �ٲ۴�
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //������Ʈ ����
        spwanObejct = Instantiate(itemObj, new Vector3(mousePos.x, 0, mousePos.z), Quaternion.identity);

        // ������Ʈ�� x�θ� �������� �ϱ� ������ y�� ����
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
