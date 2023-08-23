using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;




//저장하는 방법
//1. 저장할 데이터가 존재
//2. 데이터를 제이슨으로 변환
//3. 제이슨을 외부에 저장


public class PlayerData
    {
        public float amountofhunger; //배고픔 수치
        public Vector3 playerPosition; //현재위치
        public float thirstLevel; //목마름 수치
        public float lastSaveTime; //제일 마지막에 저장된 시간
        public string[] item;
    }

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public PlayerData nowPlayer = new PlayerData();

    public string path;
    public int nowSlot;


    private void Awake()
    {
        //싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy((instance.gameObject));
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/Uninhabitated-Save";
        print(path);
        
    }
    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
        
    }
    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
    

}
