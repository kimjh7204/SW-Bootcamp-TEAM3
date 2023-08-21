using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCollisionZone : MonoBehaviour
{
    public GameObject exitPanel;

    void Start()
    {
        exitPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        exitPanel.SetActive(true);
    }


}
