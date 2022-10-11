using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    float checkPointAmount = 0f;
    Timer timerScript;

    bool checkpoint = false;
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Checkpoint":
                if (!checkpoint)
                {
                    checkpoint = true;
                    checkPointAmount++;
                    Debug.Log(checkPointAmount);
                    
                }                
                break;     

            case "Finish":
                if (checkPointAmount == 3)
                {
                    Debug.Log("Finished!");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                else
                {
                    Debug.Log("Make sure you get all the checkpoints!");
                }
                
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Checkpoint":
                if (checkpoint)
                {
                    checkpoint = false;
                }
                break;
        }
    }

    private void Update()
    {
        LevelRestart();
    }
    void LevelRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
