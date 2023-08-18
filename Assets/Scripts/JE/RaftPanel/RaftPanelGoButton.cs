using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftPanelGoButton : MonoBehaviour
{
    public GameObject youCannotGoPanel;
    public GameObject raftPanel;

    private void Start()
    {
        youCannotGoPanel.SetActive(false);
    }

    public void RaftPanelGoButtonClick()
    {
        switch(GameData.useWhatOnOseanZone.itemTag2)
        {
            case Item.ItemTag2.raft1:
                PlayerReset();
                break;
            case Item.ItemTag2.raft2:
                PlayerReset();
                break;
            case Item.ItemTag2.raft3:
                {
                    if(CheckEnding())
                    {
                        //����
                    }
                    else
                    {
                        // â ���
                        raftPanel.SetActive(false);
                        youCannotGoPanel.SetActive(true);
                    }
                    break;
                }
        }
    }

    private void PlayerReset()
    {
        // �¸� Ÿ�� ������ ���µǴ°�.
    }

    private bool CheckEnding()
    {
        // �츮�� �ǵ��� ���ǵ��� �����ؼ� ��������� Ȯ���ϴ� �Լ�
        // �� ���� �������� �Ѿ�� �Ǹ� true ��ȯ, �ƴϸ� false ��ȯ
        return true;  // �ӽ�
    }
}
