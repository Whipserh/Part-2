using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move the arrow
        transform.Translate(-1*speed * Time.deltaTime, 0, 0);


    }


    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    
}
