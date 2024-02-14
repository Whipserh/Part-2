using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneNameText : MonoBehaviour
{
    TextMeshProUGUI sceneName;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = GetComponent<TextMeshProUGUI>();
        sceneName.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
