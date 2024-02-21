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
    float timer;
    HelthBar bar;
    
    void Start()
    {
        bar = gameObject.GetComponent<HelthBar>();
        timer = 0;
        health = MAXHEALTH;
    }

    // Update is called once per frame
    void Update() 
    {
        timer += (1 * Time.deltaTime);
        if(enemyTower && timer >= 3)//if we are the enemytower and it has been 3 seconds spawn a new bad guy
        {
            Instantiate(enemyBot, spawnPoint.transform.position, spawnPoint.transform.rotation); 
            //reset the timer
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
        bar.TakeDamage(dmg);
        health -= dmg;
    }
}
