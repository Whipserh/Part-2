using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject arrow;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(rb);
    }

    // Update is called once per frame
    void Update()
    {
        //if we clicked on the board shoot arrow in that direction
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Instantiate(arrow, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }

    }

    void FixedUpdate()
    {
        //take where the mouses location
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = -angle;
        rb.MovePosition(rb.position);
    }

}
