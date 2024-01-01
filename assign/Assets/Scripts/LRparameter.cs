using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class mapData
{
    public int wa;
    public float ma;

    
}
  
public class LRparameter : MonoBehaviour
{
    mapData mData;
    string saveFilePath;

    public Scrollbar scrollbarw;
    public Scrollbar scrollbarm;
  
    void Start()
    {
        mData = new mapData();
        saveFilePath = Application.persistentDataPath + "/mData.json";
    }
  
    void Update()
    {
        mData.ma = 26.0f + Convert.ToInt32(scrollbarm.value*30);
        mData.wa = 5 + Convert.ToInt32(scrollbarw.value*mData.ma*3);
        scrollbarw.GetComponentInChildren<TextMeshProUGUI>().text = "Path Complexity: " + mData.wa;
        scrollbarm.GetComponentInChildren<TextMeshProUGUI>().text = "Map Scale: " + mData.ma + "*" + mData.ma;
        /*
        if (Input.GetKeyDown(KeyCode.S))
            SaveGame();
  
        if (Input.GetKeyDown(KeyCode.L))
            LoadGame();
  
        if (Input.GetKeyDown(KeyCode.D))
            DeleteSaveFile();
            */
    }
  
    public void SaveGame()
    {
        string savemData = JsonUtility.ToJson(mData);
        File.WriteAllText(saveFilePath, savemData);
  
        Debug.Log("Save file created at: " + saveFilePath);
        SceneManager.LoadScene("LevelR");
    }
  
    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadmData = File.ReadAllText(saveFilePath);
            mData = JsonUtility.FromJson<mapData>(loadmData);
  
            //Debug.Log("Load game complete! \nPlayer health: " + mData.health + ", Player gold: " + mData.gold + ", Player Position: (x = " + mData.position.x + ", y = " + mData.position.y + ", z = " + mData.position.z + ")");
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