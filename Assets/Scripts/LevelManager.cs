using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Start":
                Debug.Log("Start");
                break;
            case "Sinish":
                Debug.Log("Finish");
                break;
        }
    }
}
