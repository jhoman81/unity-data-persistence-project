using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string playerName;
    public int hiScore;
    public string playerHiScoreName;

    // Start is called before the first frame update
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerHiScoreName;
        public int hiScore;
    }

    public void SaveHiScore(string playerHiScore, int hiScore)
    {
        SaveData data = new SaveData();
        data.playerHiScoreName = playerHiScore;
        data.hiScore = hiScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/hiscore.json", json);
    }

   public void LoadHiScore()
   {
        string path = Application.persistentDataPath + "/hiscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Get high score and display name
            playerHiScoreName = data.playerHiScoreName;
            hiScore = data.hiScore;
     }
   }

}
