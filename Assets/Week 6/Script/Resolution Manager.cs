using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    int width, height;
    public void SetWidth(int widthNew)
    {
        width = widthNew;
    }
    public void SetHeight(int hieghtNew)
    {
        height = hieghtNew;
    }
    public void SetResol()
    {
        Screen.SetResolution(width, height, false);
    }
}
