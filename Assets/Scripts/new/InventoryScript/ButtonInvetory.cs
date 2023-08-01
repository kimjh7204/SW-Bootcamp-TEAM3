using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ButtonInvetory : MonoBehaviour
{
    // ������ �� �κ��丮 �г� ���ְ�
    // ��ư ������ �κ��丮 ���� �״� ����

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
