using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GameData
{
    public static bool isInventoryOpen;
    public static GameObject objectShowed;
    public static GameObject droppedObejct;
    //public static List<Item> miniInventoryItems;
    public static bool isMenuPanelOpen;

    public static string playerCollisionState = null;  // 플레이어가 위치한(충돌한) 구역 이름

    public static Item useWhatOnOseanZone = null;  // 플레이어가 ocean 구역에 있을 때 사용한 아이템(뗏목)

    public static float hungry;
    public static float thirsty;

    public static Item[] inventoryItems = new Item[19];

    public static bool playerWasInCave = false;

     
}
