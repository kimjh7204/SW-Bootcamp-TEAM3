using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryTools : MonoBehaviour
{
    private RectTransform rectTransform;
    private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        gameObject.SetActive(false);
        rectTransform = GetComponent<RectTransform>();
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetInventoryTools(Vector3 pos, string text)
    {
        gameObject.SetActive(true);
        rectTransform.position = pos;
        textMeshProUGUI.text = text;
    }

    public void Disable() => gameObject.SetActive(false);
}