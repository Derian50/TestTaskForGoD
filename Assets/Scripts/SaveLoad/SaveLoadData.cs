using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public List<Item> itemList = new List<Item>();

    public List<int> quantityList = new List<int>();
}

public class SaveLoadData : MonoBehaviour
{

    #region Singleton

    public static SaveLoadData instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/playerData.json";
        LoadPlayerData();
    }

    public void SavePlayerData()
    {
        PlayerData data = new PlayerData();
        data.itemList = Inventory.instance.itemList;
        data.quantityList = Inventory.instance.quantityList;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, jsonData);

        Debug.Log("Player data saved.");
    }

    public void LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(jsonData);
            Inventory.instance.itemList = data.itemList;
            Inventory.instance.quantityList = data.quantityList;
        }
        else
        {
            Debug.Log("No saved player data found.");
        }
    }
}