using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public int bestScore = 0;
    public string bestPlayerName = "";

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int score = 0;
        public string playerName = "";
    }

    public void SaveScore() {
        SaveData data = new SaveData();
        data.score = bestScore;
        data.playerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.score;
            bestPlayerName = data.playerName;
        }
    }
    
}
