using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [Header("start scene number")]
    public int num;

    [Header("GameOver Panel")]
    public GameObject gameoverPanel;

    public static GameOverPanel instance;

    private void Start()
    {
        instance = this;
    }

    public void GoMainBtnClick()
    {
        SceneManager.LoadScene(num);
    }
}
