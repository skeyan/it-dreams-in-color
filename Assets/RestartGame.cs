﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartTheGame()
    {
        GameObject mp = GameObject.Find("MusicPlayer");
        Destroy(mp);
        SceneManager.LoadScene("Title");
    }
}
