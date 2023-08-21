using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionZoneData : MonoBehaviour
{
    [Header("tree\r\nocean\r\nfishingWater\r\nfire\r\n¡ﬂ ≈√ 1")]
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
            if(GameData.playerCollisionState == collsionZoneName)
                GameData.playerCollisionState = null;
        }
    }
}
