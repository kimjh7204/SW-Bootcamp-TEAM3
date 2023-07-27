using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour
{
    
    private Vector3  targetPos;
    private Camera mainCamera;


    // Update is called once per frame
    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        // Main Camera ������Ʈ �޾ƿ�
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            CalTargetPos();
        Run(targetPos);
    }

    private void CalTargetPos()
    {
        //������̼� �޽� �ڵ��߰��ؾ���.

        //mousePos = Input.mousePosition;
        //transPos = Camera.main.ScreenToWorldPoint(mousePos);
        //targetPos = new Vector3(transPos.x, 0, transPos.y);

        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 10000f))
                targetPos = hit.point;
        }
    
    }
    public bool Run(Vector3 targetPos)
    {
        // �̵��ϰ����ϴ� ��ǥ ���� ���� �� ��ġ�� ���̸� ���Ѵ�.
        float dis = Vector3.Distance(transform.position, targetPos);
        if (dis >= 0.01f) // ���̰� ���� �ִٸ�
        {
            // ĳ���͸� �̵���Ų��.
            transform.localPosition = Vector3.MoveTowards(transform.position, targetPos, 2f * Time.deltaTime);
            //SetAnim(PlayerAnim.ANIM_WALK); // �ȱ� �ִϸ��̼� ó��
            return true;
        }
        return false;

    }


}
