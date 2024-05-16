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
    private float colliderRadius;
    private Light2D luz;
    private int camType;
    private float damage;
    private CircleCollider2D cc2d;


    // Start is called before the first frame update
    void Start()
    {
        luz = GetComponent<Light2D>();
        cc2d = GetComponent<CircleCollider2D>();
        radius = luz.pointLightOuterRadius;
        colliderRadius = cc2d.radius;
    }

    public void SetCamType(int value) {
        if (value == 0) return;
        camType = value;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("sombraI") || other.CompareTag("sombraII") || other.CompareTag("sombraIII") || other.CompareTag("estatua")) {
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
            cc2d.radius = colliderRadius;
        } else if(camType == 2) {
            luz.pointLightOuterRadius = radius * 1.5f; 
            luz.intensity = 1;
            damage = DAMAGE_CAM_2;
            cc2d.radius = colliderRadius * 1.5f;
        }
        timerCam += Time.deltaTime;
        if (timerCam >= waitTimeCam){
            timerCam = 0.0f;
            gameObject.SetActive(false);
        }
    }
}
