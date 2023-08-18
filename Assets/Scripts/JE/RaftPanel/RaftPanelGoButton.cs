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
                        //엔딩
                    }
                    else
                    {
                        // 창 띄움
                        raftPanel.SetActive(false);
                        youCannotGoPanel.SetActive(true);
                    }
                    break;
                }
        }
    }

    private void PlayerReset()
    {
        // 뗏목 타고 나가서 리셋되는거.
    }

    private bool CheckEnding()
    {
        // 우리가 의도한 물건들을 조합해서 만들었는지 확인하는 함수
        // 다 만들어서 엔딩으로 넘어가도 되면 true 반환, 아니면 false 반환
        return true;  // 임시
    }
}
