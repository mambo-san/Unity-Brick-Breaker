using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    [SerializeField] private TMP_InputField tmpInputField;

    public string HighScorePlayer;
    public int HighScore;

    public string PlayerName;

    private void Awake()
    {
        //Basic setup
        Instance = this;
        DontDestroyOnLoad(gameObject);
        tmpInputField.onEndEdit.AddListener(TextMeshUpdated);

        //Initialize for very first play
        Instance.PlayerName = "Anonymous";
        Instance.HighScorePlayer = "";
        Instance.HighScore = 0;

        //Load data if exist
        LoadSaveData();
    }

    public void TextMeshUpdated(string playerName)
    {

        if (playerName != null || PlayerName.Length != 0) 
        {
            Instance.PlayerName = playerName;
        }
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }


    //Saving mechanism
    [Serializable]
    private class SaveData
    {
        public string playerName;
        public int score;
    }
    
    public void SaveHighScore(int score)
    {
        Instance.HighScore = score;
        Instance.HighScorePlayer = Instance.PlayerName;

        SaveData data = new SaveData();
        data.playerName = Instance.PlayerName;
        data.score = Instance.HighScore;

        string path = Application.persistentDataPath + "/saveData.json";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);

        
    }

    public void LoadSaveData()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Instance.HighScore = data.score;
            Instance.HighScorePlayer = data.playerName;
        }
    }
}
