using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControler : MonoBehaviour
{
    private float timerCam = 0.0f;
    private float waitTimeCam = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerCam += Time.deltaTime;
        if (timerCam >= waitTimeCam){
            timerCam = 0.0f;
            gameObject.SetActive(false);
        }
    }
}
