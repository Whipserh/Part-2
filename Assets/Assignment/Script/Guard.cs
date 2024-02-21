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

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {

        }
    }



    void FixedUpdate()
    {
        
    }

    //when something touches the guard
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Guard otherGuard = collision.gameObject.GetComponent<Guard>();
        if (otherGuard != null)//if they touch another guard
        {
            otherGurad.Takedamage(1);
        }

    }


    //reduce the guards health by dmg
   public void Takedamage(int dmg)
    {
        health -= dmg;
    }


}
