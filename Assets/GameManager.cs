using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool paused;

    private KeyCode pause = KeyCode.P;
    // Start is called before the first frame update
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
        // if(Input.GetKeyDown(pause)) {
        //     ChangePause(!paused);
        // }
    }
}
