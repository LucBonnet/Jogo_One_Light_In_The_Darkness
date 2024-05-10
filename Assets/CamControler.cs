using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CamControler : MonoBehaviour
{
    private const float DAMAGE_CAM_1 = 25f;
    private const float DAMAGE_CAM_2 = 50f;
    private float timerCam = 0.0f;
    private float waitTimeCam = 0.1f;
    private float radius;
    private Light2D luz;
    private int camType;
    private float damage;

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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("sombraI") || other.CompareTag("sombraII") || other.CompareTag("sombraIII")) {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.RequireReceiver);
        }
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
            damage = DAMAGE_CAM_1;
        } else if(camType == 2) {
            luz.pointLightOuterRadius = radius * 1.5f; 
            luz.intensity = 1;
            damage = DAMAGE_CAM_2;
        }
        timerCam += Time.deltaTime;
        if (timerCam >= waitTimeCam){
            timerCam = 0.0f;
            gameObject.SetActive(false);
        }
    }
}
