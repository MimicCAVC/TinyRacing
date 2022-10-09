using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    float checkPointAmount = 0f;
    Timer timerScript;
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Checkpoint":
                checkPointAmount += 1;
                Debug.Log(checkPointAmount);
                break;
            case "Finish":
                if (checkPointAmount == 5)
                {
                    Debug.Log(timerScript.t);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                else
                {
                    Debug.Log("Make sure you get all the checkpoints!");
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
