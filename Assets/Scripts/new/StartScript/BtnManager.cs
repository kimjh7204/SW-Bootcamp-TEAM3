using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public GameObject SaveSlotPanel;

    public void Start()
    {
        SaveSlotPanel.gameObject.SetActive(false);
    }
    public void OnStartBtnClick()
    {
        SceneManager.LoadScene("JE+Map 7");
    }
    public void OnExitBtnClick()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
        #else
        Application.Quit();
        #endif
        //#if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;

        //Application.Quit();
    }
    public void OnNewBtnClick()
    {
        SaveSlotPanel.gameObject.SetActive(true);
    }
    public void DeleteBtnClick()
    {
        SaveSlotPanel.gameObject.SetActive(false);
    }

}
