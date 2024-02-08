using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    
    public GameObject prefab;

    public void createDagger()
    {
        Vector2 position = new Vector2(-4, Random.Range(-3, 3));
        Quaternion orientation = Quaternion.EulerRotation(0f, 0f, -90 * Mathf.Deg2Rad);
        Instantiate(prefab, position, orientation);
    }
}
