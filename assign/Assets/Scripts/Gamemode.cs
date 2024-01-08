using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameData
{
    public int normal;
    public int infinite;

    public int imoney;

    
}
  
public class Gamemode : MonoBehaviour
{
    gameData gData;
    string saveFilePath;

    //public Scrollbar scrollbarw;
    //public Scrollbar scrollbarm;
  
    void Start()
    {
        gData = new gameData();
        saveFilePath = Application.persistentDataPath + "/gData.json";
        gData.normal = 1;
        gData.infinite = 0;
        gData.imoney = 0;
    }
  
    void Update()
    {
        /*
        gData.ma = 26.0f + Convert.ToInt32(scrollbarm.value*30);
        gData.wa = 5 + Convert.ToInt32(scrollbarw.value*gData.ma*3);
        scrollbarw.GetComponentInChildren<TextMeshProUGUI>().text = "Path Complexity: " + gData.wa;
        scrollbarm.GetComponentInChildren<TextMeshProUGUI>().text = "Map Scale: " + gData.ma + "*" + gData.ma;
        /*
        if (Input.GetKeyDown(KeyCode.S))
            SaveGame();
  
        if (Input.GetKeyDown(KeyCode.L))
            LoadGame();
  
        if (Input.GetKeyDown(KeyCode.D))
            DeleteSaveFile();
            */
    }
    public void normalmode()
    {
        gData.normal=1;
        gData.infinite=0;
        gData.imoney = 0;
        string savegData = JsonUtility.ToJson(gData);
        File.WriteAllText(saveFilePath, savegData);
  
        Debug.Log("Save file created at: " + saveFilePath);
        SceneManager.LoadScene("SelectLevel");
    }

    public void infinitemode()
    {
        gData.normal=0;
        gData.infinite=1;
        gData.imoney = 0;
        string savegData = JsonUtility.ToJson(gData);
        File.WriteAllText(saveFilePath, savegData);
  
        Debug.Log("Save file created at: " + saveFilePath);
        SceneManager.LoadScene("SelectLevel");
    }

    public void infinitemoneymode()
    {
        gData.normal=0;
        gData.infinite=0;
        gData.imoney = 1;
        string savegData = JsonUtility.ToJson(gData);
        File.WriteAllText(saveFilePath, savegData);
  
        Debug.Log("Save file created at: " + saveFilePath);
        SceneManager.LoadScene("SelectLevel");
    }


  
    public void SaveGame()
    {
        string savegData = JsonUtility.ToJson(gData);
        File.WriteAllText(saveFilePath, savegData);
  
        Debug.Log("Save file created at: " + saveFilePath);
        SceneManager.LoadScene("SampleScene");
    }
  
    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadgData = File.ReadAllText(saveFilePath);
            gData = JsonUtility.FromJson<gameData>(loadgData);
  
            //Debug.Log("Load game complete! \nPlayer health: " + gData.health + ", Player gold: " + gData.gold + ", Player Position: (x = " + gData.position.x + ", y = " + gData.position.y + ", z = " + gData.position.z + ")");
        }
        else
            Debug.Log("There is no save files to load!");
  
    }
  
    public void DeleteSaveFile()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
  
            Debug.Log("Save file deleted!");
        }
        else
            Debug.Log("There is nothing to delete!");
    }
}