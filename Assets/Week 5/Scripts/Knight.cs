using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Knight : MonoBehaviour
{
    private float MAXHEALTH = 10f;
    public float health;
    private bool clickOnSelf = false;
    private Vector2 destination;
    private Vector2 movement;
    public float speed = 5;
    public bool dead;
    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        health = MAXHEALTH;
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        movement = Vector2.zero;
        
    }
    
    // Update is called once per frame
    void Update()
    { 
        if (dead) return;
        
            if (Input.GetMouseButtonDown(0) && !clickOnSelf)
            {
                destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            animator.SetFloat("movement", movement.magnitude);
        

          
        

        
        
    }

    private void FixedUpdate()
    {
        if (dead) return;
            movement = destination - (Vector2)gameObject.transform.position;
            if (movement.magnitude < 0.1)
            {
                movement = Vector2.zero;
            }
            rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
        
    }

    //only does something if the mouse clicks on the rigidbody
    private void OnMouseDown()
    {
        if (dead) return; 
        clickOnSelf = true;
        takeDamage(1);
        
    }

    private void OnMouseUp()
    {
        clickOnSelf = false;
    }

    void takeDamage(float dmg)
    {

        health -= dmg;
        health = Mathf.Clamp(health, 0, MAXHEALTH);
        if (health <= 0)
        {
            //we die
            animator.SetTrigger("death");
            dead = true;
        }
        else
        {
            dead = false;
            //take damage
            animator.SetTrigger("takeDamage");
        }
        
        
    }
}
