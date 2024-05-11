using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PaginaController : MonoBehaviour
{
    public KeyCode interagir = KeyCode.E;
    private float time = 0.0f;
    private const float TEMPO_PISCAR = 2f;
    private const float TEMPO_ACESA = 0.3f;
    private const float LUMINOSIDADE_MAX = 0.3f;
    private bool acesa = false;
    private bool coletada = false;
    private bool playerPodeColetar = false;

    private Light2D iluminacao;

    // Start is called before the first frame update
    void Start()
    {
        iluminacao = GetComponent<Light2D>();
        iluminacao.intensity = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerPodeColetar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerPodeColetar = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(acesa && time > TEMPO_ACESA) {
            time = 0f;
            iluminacao.intensity = 0;
            acesa = false;
        } 
        
        if (!acesa && time > TEMPO_PISCAR) {
            time = 0f;
            iluminacao.intensity = LUMINOSIDADE_MAX;
            acesa = true;
        }

        if(playerPodeColetar && Input.GetKey(interagir)) {
            coletada = true;
        }
        
        iluminacao.enabled = !coletada;
    }
}
