using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ButtonInvetory : MonoBehaviour
{
    // 시작할 때 인벤토리 패널 꺼주고
    // 버튼 누르면 인벤토리 껐다 켰다 해줌

    public GameObject Inventorypanel;

    private void Start()
    {
        Inventorypanel.SetActive(false);
        GameData.isInventoryOpen = false;
    }

    public void OnClick()
    {
        if (GameData.isInventoryOpen)
        {
            Inventorypanel.SetActive(false);
            GameData.isInventoryOpen = false;
        }
        else
        {
            Inventorypanel.SetActive(true);
            GameData.isInventoryOpen = true;
        }
    }
}
