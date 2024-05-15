using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controle_elevador : MonoBehaviour
{

    public Sprite novoSprite,novoSprite0,novoSprite1,novoSprite2,novoSprite3,novoSprite4,novoSprite5,novoSprite6;
    public KeyCode terreo = KeyCode.Alpha0;
    public KeyCode andar1 = KeyCode.Alpha1;
    public KeyCode andar2 = KeyCode.Alpha2;
    public KeyCode andar3 = KeyCode.Alpha3;
    public KeyCode andar4 = KeyCode.Alpha4;
    public KeyCode andar5 = KeyCode.Alpha5;
    public KeyCode entrar = KeyCode.E;
    public KeyCode sair = KeyCode.Escape;
    public KeyCode aceitar = KeyCode.KeypadEnter;
    public static bool ativado = false;
    private int andar = 100;
    public Color corDoTexto = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {            
        if (hitInfo.CompareTag("Player")){
                ativado = true;               
        } 
    }

    void OnTriggerExit2D (Collider2D hitInfo) {      
            ativado = false;                       
    }

    
    void OnGUI () {
        GUI.contentColor = corDoTexto;
        if(controle_elevador.ativado){
            Scene scene = SceneManager.GetActiveScene();
            if (andar ==100){
                 GUI.Label(new Rect(Screen.width / 2 - 20 - 12, 150, 600, 600), "Aperte E para abrir o painel");
            }
           
            if (Input.GetKey(entrar)) {
                GameManager.ChangePause(true);
                andar = 50;
                GetComponent<SpriteRenderer>().sprite = novoSprite;
            }
            if (Input.GetKey(terreo)) {
               GetComponent<SpriteRenderer>().sprite = novoSprite0;
               andar =0;
            }
            if (Input.GetKey(andar1)) {
                GetComponent<SpriteRenderer>().sprite = novoSprite1;
                andar =1;
            }
            if (Input.GetKey(andar2)) {
                GetComponent<SpriteRenderer>().sprite = novoSprite2;
                andar =2;
            }
            if (Input.GetKey(andar3)) {
               GetComponent<SpriteRenderer>().sprite = novoSprite3;
               andar =3;
            }
            if (Input.GetKey(andar4)) {
                GetComponent<SpriteRenderer>().sprite = novoSprite4;
                andar =4;
            }
            if (Input.GetKey(andar5)) {
                GetComponent<SpriteRenderer>().sprite = novoSprite5;
                andar =5;
            }

            if (Input.GetKey(sair)) {
                GetComponent<SpriteRenderer>().sprite = novoSprite6;
                andar = 100;
                GameManager.ChangePause(false);
            }
            if (Input.GetKey(aceitar)) {
                if(andar == 0){
                    SceneManager.LoadScene("Terreo");
                }
                if(andar == 1){
                    SceneManager.LoadScene("1Andar");
                }
                if(andar == 2){
                    SceneManager.LoadScene("2Andar");
                }
                if(andar == 3){
                    SceneManager.LoadScene("3Andar");
                }
                if(andar == 4){
                    SceneManager.LoadScene("4Andar");
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
      //Debug.Log(andar);  
    }
}
