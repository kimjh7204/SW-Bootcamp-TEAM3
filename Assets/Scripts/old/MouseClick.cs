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
        // Main Camera 오브젝트 받아옴
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            CalTargetPos();
        Run(targetPos);
    }

    private void CalTargetPos()
    {
        //내비게이션 메쉬 코드추가해야함.

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
        // 이동하고자하는 좌표 값과 현재 내 위치의 차이를 구한다.
        float dis = Vector3.Distance(transform.position, targetPos);
        if (dis >= 0.01f) // 차이가 아직 있다면
        {
            // 캐릭터를 이동시킨다.
            transform.localPosition = Vector3.MoveTowards(transform.position, targetPos, 2f * Time.deltaTime);
            //SetAnim(PlayerAnim.ANIM_WALK); // 걷기 애니메이션 처리
            return true;
        }
        return false;

    }


}
