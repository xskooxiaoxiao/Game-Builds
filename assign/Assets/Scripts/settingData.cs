using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class setData
{
    public float audio;
    public float bright;

    
}
  
public class settingData : MonoBehaviour
{
    setData sData;
    string saveFilePath;

    public Scrollbar scrollbarw;
    public Scrollbar scrollbarm;
  
    void Start()
    {
        sData = new setData();
        saveFilePath = Application.persistentDataPath + "/sData.json";
    }
  
    void Update()
    {
        sData.audio = scrollbarw.value;
        sData.bright = scrollbarm.value;
        
        scrollbarw.GetComponentInChildren<TextMeshProUGUI>().text = "Audio: " + sData.audio;
        scrollbarm.GetComponentInChildren<TextMeshProUGUI>().text = "Brightness: " + sData.bright;
        
    }
  
    public void SaveGame()
    {
        string savesData = JsonUtility.ToJson(sData);
        File.WriteAllText(saveFilePath, savesData);
  
        Debug.Log("Save file created at: " + saveFilePath);
        SceneManager.LoadScene("MainMenu");
    }
  
    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadsData = File.ReadAllText(saveFilePath);
            sData = JsonUtility.FromJson<setData>(loadsData);
  
            //Debug.Log("Load game complete! \nPlayer health: " + sData.health + ", Player gold: " + sData.gold + ", Player Position: (x = " + sData.position.x + ", y = " + sData.position.y + ", z = " + sData.position.z + ")");
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