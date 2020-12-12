using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveGame : MonoBehaviour
{
    //싱글톤====================
    static GameObject _container;

    static SaveGame _instance;
    public static SaveGame Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "SaveGame";
                _instance = _container.AddComponent(typeof(SaveGame)) as SaveGame;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }
    // =================================================

    public string GameDataFileName = ".json";

    private string filePath = "";

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if (_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }
    private void Awake()
    {
        filePath = string.Concat(Application.persistentDataPath, GameDataFileName);
        Debug.Log(filePath);
    }

    public void LoadGameData()
    {
        if (File.Exists(filePath))
        {
            Debug.Log("불러오기");
            string code = File.ReadAllText(filePath);

            byte[] bytes = System.Convert.FromBase64String(code);
            string FromJsonData = System.Text.Encoding.UTF8.GetString(bytes);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else
        {
            Debug.Log("새로운 파일 생성");
            _gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData, true);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(ToJsonData);
        string code = System.Convert.ToBase64String(bytes);

        File.WriteAllText(filePath, code);
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    private void Start()
    {
        InvokeRepeating("AutoSave", 0, 30);

    }
    private void AutoSave()
    {
        SaveGameData();
        Debug.Log("Save Complete");
    }
}
