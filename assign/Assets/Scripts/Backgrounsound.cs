using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Backgrounsound : MonoBehaviour

  {
    public AudioSource soundPlayer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Bgm()
    {
        soundPlayer.Play();
    }
}