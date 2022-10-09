using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsHandler : MonoBehaviour
{
    [SerializeField] AudioSource carStart;
    void Start()
    {
        
    }

    
    void Update()
    {
        CarEngineStart();
    }

    void CarEngineStart()
    {
        if (Input.GetKey(KeyCode.W) && !carStart.isPlaying)
        {
            carStart.Play();
            Debug.Log("WWWWWWW");
        }
    }
}
