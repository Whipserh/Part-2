using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{

    public float speed = 5;
    public int health = 3;
    public GameObject objective;
    bool dead = false;
    bool move = true;
    // Update is called once per frame
    void Update()
    {
        //if their health is 0, then die
        if(health <= 0)
        {
            //animate death
            gameObject.GetComponent<Animator>().SetTrigger("death");
            //destroy but give time for death animation
            Destroy(gameObject, 1);
            dead = true;
        }
    }


    //DONE
    void FixedUpdate()//guard should always be moving right
    {
        if (dead) return;//if we are dead then don't do anything
        Vector2 movement = (Vector2)(objective.transform.position - gameObject.transform.position);//get the vector towards the person
        if (move)//if we are supposed to move
        { 
            gameObject.GetComponent<Animator>().SetBool("walk", true);//set animation to walk
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);//move towards objective
        }
    }


    //when something touches the guard
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Guard touched the tower");
        //stop moving
        move = false;
        gameObject.GetComponent<Animator>().SetBool("walk", false);
        //check to see if they touched a guard or a tower
        Guard otherGuard = collision.gameObject.GetComponent<Guard>();
        Tower tower = collision.gameObject.GetComponent<Tower>();
        if (otherGuard != null)//if they touch another guard
        {
            otherGuard.Takedamage(1);
        }else if (tower != null)//if the guard touches the tower it should destroy itself
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)//when we are no longer in contact with anything then move again
    {
        move = true;
    }


    //reduce the guards health by dmg
   public void Takedamage(int dmg)
    {
        health -= dmg;
    }


}
