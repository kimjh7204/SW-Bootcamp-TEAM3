using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PlayerData
    {
        public int amountofhunger;
        public float location;
    }

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    PlayerData nowPlayer = new PlayerData();

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy((instance.gameObject));
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }
        
    void Update()
    {
        
    }
}
