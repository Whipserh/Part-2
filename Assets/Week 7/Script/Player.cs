using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject based;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selected(bool selected)
    {
        if (selected)
        {
            based.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            based.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    private void OnMouseDown()
    {
        Selected(true);
    }

    private void OnMouseUp()
    {
        Selected(false);
    }

    
}
