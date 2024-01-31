using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        trailPath = GetComponent<LineRenderer>();
        trailPath.positionCount = 1;
        trailPath.SetPosition(0, transform.position);

        rigidbody = GetComponent<Rigidbody2D>();
    }

    //this updates every time our rigidbody moves
    private void FixedUpdate()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
        if(points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
            
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up*speed*Time.deltaTime);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {   
            landingTime += 0.1f * Time.deltaTime;
            float interpolation = Landing.Evaluate(landingTime)*Time.deltaTime*speed;
            if(transform.localScale.x < 0.1f)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
            }
        }

        if(points.Count > 0)
        {
            if(Vector2.Distance((Vector2)transform.position, points[0]) < pointThreshold){
                points.RemoveAt(0);

                for (int i = 0; i < trailPath.positionCount - 2; i++)
                {
                    trailPath.SetPosition(i, trailPath.GetPosition(i + 1));
                }
                trailPath.positionCount--;
            }

        }
    }
    public float speed = 1f;
    Rigidbody2D rigidbody;
    LineRenderer trailPath;
    public List<Vector2> points;
    Vector2 lastPosition;
    Vector2 currentPosition;
    public float pointThreshold = 0.2f;
    public float landingSpeed = 5;
    public AnimationCurve Landing;
    float landingTime;
    //when we first click on the plane
    private void OnMouseDown()
    {
        //gets ready to make a new flight path
        points = new List<Vector2>();

        //reset the path trail
        trailPath.positionCount = 1;
        trailPath.SetPosition(0, transform.position);
    }

    //as we are holding down the mouse button, we create a flight path based on the position of the mouse in the world.
    private void OnMouseDrag()
    {
        //get the current location of the mouse
        currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //we check to see if the point is far enough away from the point
        if (Vector2.Distance(currentPosition, lastPosition) >= pointThreshold)
        {
            points.Add(currentPosition);
            trailPath.positionCount++;
            trailPath.SetPosition(trailPath.positionCount-1, currentPosition);
            lastPosition = currentPosition;
        }
        

    }


    //when we let go of the mouse we want the plane to start moving to the points
    private void OnMouseUp() {

    
    }

}//end of class
