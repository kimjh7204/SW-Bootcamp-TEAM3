using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionZoneData : MonoBehaviour
{
    public string collsionZoneName;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameData.playerCollisionState = collsionZoneName;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameData.playerCollisionState = null;
        }
    }
}
