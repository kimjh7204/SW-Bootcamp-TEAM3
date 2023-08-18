using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SelectSlot : MonoBehaviour
{

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {

            }
        }
    }

        
    
    void Update()
    {
        
    }

    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;
        DataManager.instance.LoadData();
        GoGame();
    }

    public void GoGame()
    {
        SceneManager.LoadScene(1);
    }
    
}
