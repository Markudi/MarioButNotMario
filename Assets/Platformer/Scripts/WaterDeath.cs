using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour
{


    private Camera mainCamera;
    
    public AudioClip downOneAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }


    private void OnTriggerEnter(Collider other)
    {
        mainCamera.GetComponent<AudioSource>().Stop();
        mainCamera.GetComponent<AudioSource>().PlayOneShot(downOneAudio, 1f);


        if (other.gameObject.name == "Player")
        {
            Destroy(other.gameObject);
        }
        
    }
}
