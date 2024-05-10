using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CamControler : MonoBehaviour
{
    private float timerCam = 0.0f;
    private float waitTimeCam = 0.1f;
    private float radius;
    private Light2D luz;
    private int camType;

    // Start is called before the first frame update
    void Start()
    {
        luz = GetComponent<Light2D>();
        radius = luz.pointLightOuterRadius;
    }

    public void SetCamType(int value) {
        if (value == 0) return;
        camType = value;
    }

    // Update is called once per frame
    void Update()
    {
        if(camType == 0) {
            gameObject.SetActive(false);
            return;
        }

        if(camType == 1) {
            luz.pointLightOuterRadius = radius;
            luz.intensity = 1;
        } else if(camType == 2) {
            luz.pointLightOuterRadius = radius * 1.5f; 
            luz.intensity = 1;
        }
        timerCam += Time.deltaTime;
        if (timerCam >= waitTimeCam){
            timerCam = 0.0f;
            gameObject.SetActive(false);
        }
    }
}
