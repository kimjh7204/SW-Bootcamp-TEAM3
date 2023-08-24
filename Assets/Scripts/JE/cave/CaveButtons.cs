using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveButtons : MonoBehaviour
{
    public GameObject exitPanel;

    [Header("main game scene number")]
    public int gameSceneNum;

    void Start()
    {
        exitPanel.SetActive(false);
    }

    public void YesButtonClick()
    {
        // scene ÀüÈ¯

        GameData.hungry = StateBar1.instance.hungry;
        GameData.thirsty = StateBar2.instance.thirst;

        GameData.playerWasInCave = true;
        SceneManager.LoadScene(gameSceneNum);
    }

    public void NoButtonClick()
    {
        exitPanel.SetActive(false);
    }
}
