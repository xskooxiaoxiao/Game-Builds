using UnityEngine;

public class VolumeController : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    float m_MySliderValue;

    void Start()
    {
        m_MySliderValue = PlayerPrefs.GetFloat("AudioVolume", 0.5f); // Load the saved audio volume or use a default value
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.volume = m_MySliderValue; // Set the volume initially
        m_MyAudioSource.Play();
    }

    void OnGUI()
    {
        // Increase the height and length of the slider
        m_MySliderValue = GUI.HorizontalSlider(new Rect(25, 25, 300, 80), m_MySliderValue, 0.0f, 1.0f);
        m_MyAudioSource.volume = m_MySliderValue;

        // Display the "Audio" label on the right side of the slider with increased size and green color
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 16;
        style.normal.textColor = Color.green;
        GUI.Label(new Rect(330, 25, 100, 30), "Audio", style);

        // Save the audio volume when the slider is adjusted
        if (GUI.changed)
        {
            PlayerPrefs.SetFloat("AudioVolume", m_MySliderValue);
            PlayerPrefs.Save();
        }
    }
}
