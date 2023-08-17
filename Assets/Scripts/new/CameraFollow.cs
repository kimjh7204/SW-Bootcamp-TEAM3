using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public float rotateSpeed = 500.0f;
    private float xRotateMove;

    Vector2 clickPoint;
    float dragSpeed = 30.0f;

    private void Start()
    {
   
    }

    private void Update()
    {
        transform.position = player.transform.position;

        if (Input.GetMouseButton(1))
        {
            xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
            transform.Rotate(0, xRotateMove, 0);
        }
    }

}
