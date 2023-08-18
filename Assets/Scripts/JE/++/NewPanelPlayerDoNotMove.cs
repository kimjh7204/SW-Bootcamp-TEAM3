using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewPanelPlayerDoNotMove : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public void OnPointerExit(PointerEventData eventData)
    { // �̴�â ���� ������ Ŭ������ �� �÷��̾ �ǵ�ġ �ʰ� �����̴� ���� ���� ����.
        PlayerController.playerCanMove = false;  //+
    }

    public void OnPointerEnter(PointerEventData eventData)
    { // �̴�â ���� ������ Ŭ������ �� �÷��̾ �ǵ�ġ �ʰ� �����̴� ���� ���� ����.
        PlayerController.playerCanMove = true;  //+
    }
}
