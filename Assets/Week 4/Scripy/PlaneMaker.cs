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
    }
    float timer;
    Transform trans;
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
            Quaternion orientation = Quaternion.EulerRotation(0, 0, (angle+(Random.Range(-22.5f,22.5f))));
            int num = Random.Range(1,4);
            num = 1;
            Debug.Log(angle);


            switch (num)
            {
                case 1:
                    Instantiate(prefab1, position, orientation);
                    break;

            }

            timer = 0;
        }//end if
    }
}
