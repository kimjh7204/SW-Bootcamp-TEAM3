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

    public static string playerCollisionState = null;  // �÷��̾ ��ġ��(�浹��) ���� �̸�

    public static Item useWhatOnOseanZone = null;  // �÷��̾ ocean ������ ���� �� ����� ������(�¸�)

    public static float hungry;
    public static float thirsty;

    public static Item[] inventoryItems = new Item[19];

    public static bool playerWasInCave = false;

     
}
