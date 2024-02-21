using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{


    public int health = 100;
    public bool enemyTower = false;
    int MAXHEALTH = 100;
    public GameObject spawnPoint;
    public GameObject enemyBot;
    int timer;

    
    void Start()
    {
        timer = 0;
        health = MAXHEALTH;
    }

    // Update is called once per frame
    void Update() 
    {
        timer += (int)(1 * Time.deltaTime);
        if(enemyTower && timer >= 3)//if we are the enemytower and it has been 3 seconds spawn a new bad guy
        {
            Instantiate(enemyBot, spawnPoint.transform.position, spawnPoint.transform.rotation); 
            //reset the timer
            timer = 0;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Arrow>() != null)//if a arrow touches the tower
        {
            TakeDamage(1);
        }else if (collision.gameObject.GetComponent<Guard>() != null)//if a guard touches the tower
        {
            TakeDamage(10);
        }

    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }
}
