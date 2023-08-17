using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;

    [SerializeField] float minDistance = 3f;
    [SerializeField] float maxDistance = 30f;
    [SerializeField] float wheelSpeed = 500f;
    [SerializeField] float xMoveSpeed = 500f;  // 카메라의 y축 회전 속도
    [SerializeField] float yMoveSpeed = 200f;  // 카메라의 x축 회전 속도
    private float yMinLimit = 5f;  // 회전 제한 최솟값
    private float yMaxLimit = 80f;  // 회전 제한 최댓값
    private float x, y;
    private float distance;


    void Awake()
    {
        distance = Vector3.Distance(transform.position, target.position);
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void Update()
    {
        if (target == null) return;

        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xMoveSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * yMoveSpeed * Time.deltaTime;

            y = ClampAnge(y, yMinLimit, yMaxLimit);
            transform.rotation = Quaternion.Euler(y, x, 0);
        }

        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    private void LateUpdate()
    {
        if (target == null) return;

        transform.position = transform.rotation * new Vector3(0, 0, -distance) + target.position;

    }


    private float ClampAnge(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
