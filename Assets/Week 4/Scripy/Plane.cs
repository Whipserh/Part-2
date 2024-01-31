using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        trailPath = GetComponent<LineRenderer>();
        trailPath.positionCount = 1;

        trailPath.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    LineRenderer trailPath;
    public List<Vector2> points;
    Vector2 lastPosition;
    public float pointThreshold = 0.2f;

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
        Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
