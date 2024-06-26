using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScreenResolution : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
    }
}
