using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class VolumeSFX : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    //float m_MySliderValue;
	
    setData sData;
    string saveFilePath;
    // Start is called before the first frame update
    void Start()
    {
        sData = new setData();
        saveFilePath = Application.persistentDataPath + "/sData.json";
        string loadsData = File.ReadAllText(saveFilePath);
        sData = JsonUtility.FromJson<setData>(loadsData);
        //audioParam = sData.audio;
        //brightness = sData.bright;
        //m_MySliderValue = PlayerPrefs.GetFloat("AudioVolume", 0.5f); // Load the saved audio volume or use a default value
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.volume = sData.sfx; // Set the volume initially
        m_MyAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
