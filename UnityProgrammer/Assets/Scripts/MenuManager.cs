using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public string playerName;
    public int score;
    public string currentName;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    class SavedData
    {
        public string name;
        public int score;
    }
    public void SaveData()
    {
        SavedData data = new SavedData();
        data.name = playerName;
        data.score = score;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath + "/savefile.json");
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);

            score = data.score;
            playerName = data.name;
        }
    }

}
