using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{



    // a static variable is a variable that is shared amoung all copies of the same class
    //so if one controller changes the score from 2 to 3, all copies would make that same change
    public static Player SelectedPlayer { get; private set; }

    public static float score = 0;
    public Slider slider;
    bool counting;
    float timer;
    public int maxForce = 2;
    Vector2 direction = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
        timer = 0;
        counting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedPlayer == null) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            counting = true;
        } else if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector2 playerPos = new Vector2(SelectedPlayer.transform.position.x, SelectedPlayer.transform.position.y);//get the players pos
            direction = playerPos - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);//find the direction we are going
            counting = false;

        }

        if (counting)
        {
            timer += Time.deltaTime;
            slider.value = Mathf.Abs(Mathf.Sin(timer * 100 * Mathf.Deg2Rad));//on a sin 
        }
    }

    private void FixedUpdate()
    {
        if(direction != Vector2.zero)
        {

            
            //apply force
            SelectedPlayer.GetComponent<Rigidbody2D>().AddForce(-direction.normalized * slider.value * maxForce);
            direction = Vector2.zero;
            timer = 0;

        }
    }

    public static void SetSelectedPlayer(Player newSelected)
    {
        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);//unselect the one that we currently have
        }
        //select the new one
        SelectedPlayer = newSelected; 
        SelectedPlayer.Selected(true);
    }


}


