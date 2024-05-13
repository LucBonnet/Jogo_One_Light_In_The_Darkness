using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool paused;
    
    void Start()
    {
        paused = false;
    }

    public static void ChangePause(bool p) {
        Time.timeScale = p ? 0 : 1;
        paused = p;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
