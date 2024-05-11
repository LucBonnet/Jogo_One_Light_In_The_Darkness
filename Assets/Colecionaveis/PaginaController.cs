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
    private bool playerPodeColetar = false; 
    public GameObject paginaLer;
    private GameObject instanciaPagina;
    private GameObject player;
    private Light2D iluminacao;
    public Sprite spritePagina;

    private bool paginaAberta = false;

    // Start is called before the first frame update
    void Start()
    {
        iluminacao = GetComponent<Light2D>();
        iluminacao.intensity = 0;
        player = GameObject.FindGameObjectWithTag("Player");
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

    private void LerPagina() {
        Debug.Log("ler");
        SpriteRenderer spr = paginaLer.GetComponent<SpriteRenderer>();
        spr.sprite = spritePagina;
        instanciaPagina = Instantiate(paginaLer, player.transform.position, Quaternion.identity);
        paginaAberta = true;
        GameManager.ChangePause(true);
    }

    private void FecharPagina() {
        if(!instanciaPagina) return;
        Destroy(instanciaPagina);
        paginaAberta = false;
        GameManager.ChangePause(false);
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

        if(!paginaAberta && playerPodeColetar && Input.GetKeyDown(interagir)) {
            LerPagina();
        } else if(paginaAberta && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(interagir))) {
            FecharPagina();
        }
    }
}
