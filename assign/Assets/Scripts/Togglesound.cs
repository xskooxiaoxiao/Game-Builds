using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Togglesound : MonoBehaviour
{
    public AudioSource soundPlayer;
   
    // Update is called once per frame
    void Update()
    {

    }
    public void toggleSound()
    {
        soundPlayer.Play();
    }
}