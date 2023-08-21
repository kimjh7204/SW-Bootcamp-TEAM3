using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public static FireController instance;
    public static bool isFireOn;

    [Header("��ں� ������Ʈ 2�� (��ƼŬ&��)")]
    public GameObject fireTarget1;
    public GameObject fireTarget2;

    void Start()
    {
        instance = this;
        if(isFireOn)
        {
            if(Random.Range(1,101) <= 50) isFireOn = false;
        }
        fireTarget1.SetActive(isFireOn);
        fireTarget2.SetActive(isFireOn);
    }

    public void SetFire()
    {
        isFireOn = true;
        fireTarget1.SetActive(isFireOn);
        fireTarget2.SetActive(isFireOn);
    }
}
