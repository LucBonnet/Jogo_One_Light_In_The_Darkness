using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightControl : MonoBehaviour
{
    private Light2D luz;

    private const float initialIntensity = 0.03f;
    private float intensity;
    private bool acendendo;
    private static bool aceso = false;

    private float timer = 0f;
    private const float waitTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        luz = GetComponent<Light2D>();  
        intensity = initialIntensity;
        acendendo = false;
    }

    public void Acender() {
        acendendo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(aceso) {
            luz.intensity = 1f;
            return;    
        }

        luz.intensity = intensity;
        if(acendendo && !aceso) {
            timer += Time.deltaTime;
            if(timer >= waitTime) { 
                timer = 0f;
                intensity += Mathf.Min(0.01f, 1f);
            }
        }

        if(intensity >= 1f) {
            aceso = true;
            GameObject[] sombras = GameObject.FindGameObjectsWithTag("sombraI");
            foreach(GameObject sombra in sombras) {
                Destroy(sombra);
            }

            sombras = GameObject.FindGameObjectsWithTag("sombraII");
            foreach(GameObject sombra in sombras) {
                Destroy(sombra);
            }

            sombras = GameObject.FindGameObjectsWithTag("sombraIII");
            foreach(GameObject sombra in sombras) {
                Destroy(sombra);
            }
        }
    }
}
