using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); // persist through scenes
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        if(scene.name == "Level_Two")
        {
            GameObject c = GameObject.Find("Character");
            PlayerController pc = c.GetComponent<PlayerController>();
            pc.shouldTakeInput = true;
        }

    }
}
