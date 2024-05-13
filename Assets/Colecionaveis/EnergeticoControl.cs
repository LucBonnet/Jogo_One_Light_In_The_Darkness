using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnergeticoControl : MonoBehaviour
{
    public KeyCode interagir = KeyCode.E;
    private float time = 0.0f;
    private const float TEMPO_PISCAR = 2f;
    private const float TEMPO_ACESO = 0.3f;
    private const float LUMINOSIDADE_MAX = 0.3f;
    private const float STAMINA_ADICIONADA = 10f;
    private bool aceso = false;
    private bool playerPodeColetar = false; 
    private Light2D iluminacao;
    public Stamina stamina;

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

    private void Coletar() {
        stamina.maxStamina += STAMINA_ADICIONADA;
        stamina.stamina = stamina.maxStamina;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(aceso && time > TEMPO_ACESO) {
            time = 0f;
            iluminacao.intensity = 0;
            aceso = false;
        } 
        
        if (!aceso && time > TEMPO_PISCAR) {
            time = 0f;
            iluminacao.intensity = LUMINOSIDADE_MAX;
            aceso = true;
        }

        if(playerPodeColetar && Input.GetKeyDown(interagir)) {
            Coletar();
        } 
    }
}
