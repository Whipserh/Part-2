using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
    int nextSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
