using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingText : MonoBehaviour
{
    public TextMeshProUGUI text;
    private string t = "I'm free....";
    public GameObject button;
    [Header("start scene number")]
    public int num;


    void Start()
    {
        StartCoroutine(ShowText());
    }


    private IEnumerator ShowText()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < t.Length; i++)
        {
            text.text = t.Substring(0, i);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1f);
        button.SetActive(true);
    }

    public void GoMainButtonClick()
    {
        SceneManager.LoadScene(num);
    }

}
