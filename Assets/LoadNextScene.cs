using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    AudioSource a;
    private void Start()
    {
        a = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
    public void LoadNext()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            a.enabled = false;

        }
        Debug.Log("loading next scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
