using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsHandler : MonoBehaviour
{
    [SerializeField] AudioSource carStartSound;
    [SerializeField] AudioSource MeepMeepSound;
     
    void Start()
    {
        

        
    }   

    
    void Update()
    {
        //CarEngineStart();
        MeepMeep();

        
    }

    void CarEngineStart()
    {
        if (Input.GetKey(KeyCode.W) && !carStartSound.isPlaying)
        {
            
            carStartSound.Play();            
        }
        else if (Input.GetKeyUp(KeyCode.W) && carStartSound.isPlaying)
        {
            carStartSound.Stop();
        }
    }

    void MeepMeep()
    {
        if (Input.GetKey(KeyCode.Space) && !MeepMeepSound.isPlaying)
        {
            
            MeepMeepSound.Play();
        }
        
    }
}
