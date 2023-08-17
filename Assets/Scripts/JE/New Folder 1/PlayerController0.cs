using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController0 : MonoBehaviour
{
    public float moveSpeed;
    

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            transform.position += new Vector3(x * moveSpeed * Time.deltaTime, 0, z * moveSpeed * Time.deltaTime);
        }
    }
}
