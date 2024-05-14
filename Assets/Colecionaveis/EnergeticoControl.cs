using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnergeticoControl : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    private void GenerateGuid() {
        id = System.Guid.NewGuid().ToString();
    }

    public KeyCode interagir = KeyCode.E;
    private float time = 0.0f;
    private const float TEMPO_PISCAR = 2f;
    private const float TEMPO_ACESO = 0.3f;
    private const float LUMINOSIDADE_MAX = 0.3f;
    private const float STAMINA_ADICIONADA = 10f;
    private bool aceso = false;
    private bool playerPodeColetar = false; 
    private Light2D iluminacao;
    private bool coletada;

    // Start is called before the first frame update
    void Start()
    {
        iluminacao = GetComponent<Light2D>();
        iluminacao.intensity = 0;
        coletada = false;
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
        Stamina.maxStamina += STAMINA_ADICIONADA;
        Stamina.stamina = Stamina.maxStamina;
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

    public void LoadData(GameData data) {
        data.energeticosColetados.TryGetValue(id, out coletada);
        if(coletada) {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data) {
        if(data.energeticosColetados.ContainsKey(id)) {
            data.energeticosColetados.Remove(id);
        }
        
        data.energeticosColetados.Add(id, coletada);
    }
}
