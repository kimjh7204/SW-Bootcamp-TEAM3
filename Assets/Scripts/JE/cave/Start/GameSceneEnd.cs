using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEnd : MonoBehaviour
{
    void Start()
    {
        GameData.hungry = StateBar1.instance.hungry;
        GameData.thirsty = StateBar2.instance.thirst;
    }

}
