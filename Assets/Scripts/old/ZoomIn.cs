using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomIn : MonoBehaviour
{

    private Camera mainCamera;
    private Vector3 CamOrigin,CamMove;
    private GameObject btn;
    private bool IsZoom;


    void Start()
    {
        mainCamera = GetComponent<Camera>();
        CamOrigin = mainCamera.transform.position;
        

        btn = GameObject.Find("back");
        btn.SetActive(false);

    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(1)&& Input.mousePosition.y<=900 && Input.mousePosition.y >= 100&& IsZoom==false)
        {
            mainCamera.orthographicSize = 15;
            CamMove = mainCamera.transform.position;

            btn.SetActive(true);
            IsZoom = true;
            Debug.Log(Input.mousePosition);
            if (Input.mousePosition.x <= 960 && Input.mousePosition.y <= 450)
            {

                Debug.Log("왼쪽 아래");
                //mainCamera.transform.Translate(CamOrigin); // 자기 중심 기준 이동.
                CamMove += new Vector3(-15f, -15f, 0f); //오프셋 만큼 이동
                mainCamera.transform.position = CamMove;
                
            }
            else if (Input.mousePosition.x <= 960 && Input.mousePosition.y > 450)
            {

                Debug.Log("왼쪽 위");
                CamMove += new Vector3(-17f, 10f, 18f);
                mainCamera.transform.position = CamMove;
                
            }
            else if (Input.mousePosition.x >= 960 )
            {

                Debug.Log("오른쪽");
                CamMove += new Vector3(15f, 5f, -4f);
                mainCamera.transform.position = CamMove;
                
            }
            
        }
        
    }
    public void BtnClick()
    {
        mainCamera.orthographicSize = 30;
        mainCamera.transform.position=CamOrigin;
        btn.SetActive(false);
        IsZoom = false;
    }
    
}
