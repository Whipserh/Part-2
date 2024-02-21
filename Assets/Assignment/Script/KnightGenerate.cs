using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightGenerate : MonoBehaviour
{
    public GameObject knight;
    public GameObject spawnLocation;

    public void createKnight() { 
        Instantiate(knight, spawnLocation.transform.position, spawnLocation.transform.rotation);
    }

}
