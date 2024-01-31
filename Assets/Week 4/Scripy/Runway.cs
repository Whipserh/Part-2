using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int score = 0;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.transform.position)
        
            score++;
        
    }
}
