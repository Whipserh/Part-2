using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneMaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        timer = 0;
        spawnRate = Random.Range(1, 5);
    }
    float timer;
    Transform trans;
    int spawnRate;
    public GameObject prefab1, prefab2, prefab3, prefab4;
    // Update is called once per frame
    void Update()
    {
        timer = timer +(1f * Time.deltaTime);

        if (timer >=2)
        {

            Vector2 position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            Vector2 direction = (Vector2)trans.position - position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            Quaternion orientation = Quaternion.EulerRotation(0f, 0f, angle);//some how its random idk how
            int num = Random.Range(1,4);

            switch (num)
            {
                case 1:
                    Instantiate(prefab1, position, orientation);
                    break;
                case 2:
                    Instantiate(prefab2, position, orientation);
                    break;
                case 3:
                    Instantiate(prefab3, position, orientation);
                    break;
                case 4:
                    Instantiate(prefab4, position, orientation);
                    break;
            }

            spawnRate = Random.Range(1, 5);
            timer = 0;
        }//end if
    }
}
