using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDonotMoveUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Ŭ������ �� �÷��̾ �����̸� �ȵǴ� UI�� ���� ��ũ��Ʈ

    public void OnPointerEnter(PointerEventData eventData)
    {
        NavData.playerCanMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        NavData.playerCanMove = true;
    }
}
