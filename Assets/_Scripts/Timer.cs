using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float timerTime = 0f;
    public float t;
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            timerTime = Time.timeSinceLevelLoad;         
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            t = Time.timeSinceLevelLoad - timerTime;

            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;
        }
        LevelRestart();

    }
    void LevelRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            timerTime = 0f;
        }
    }
}

