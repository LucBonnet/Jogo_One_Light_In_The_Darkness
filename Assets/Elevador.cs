using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevador : MonoBehaviour
{
   public GUISkin layout;
    public static bool subir = false;
    public static bool esse_elevador = false;
    public Color corDoTexto = Color.red; // Defina a cor desejada aqui
    private Animator anime;


    public KeyCode trocar = KeyCode.E;


    // Start is called before the first frame update
    void Start()
    {
       anime = GetComponent<Animator>();
    }

    public void Esse_Elevador(){
        esse_elevador = true;
    }

    public  void PlayerAnimation(){
        anime.Play("porta_elevador");
    }
    void OnTriggerEnter2D (Collider2D hitInfo) {     
        
            if (hitInfo.CompareTag("Player")){
           		    subir = true; 
            } 
    }
    void OnTriggerExit2D (Collider2D hitInfo) {      
           		subir = false;                        
    }
    void OnGUI () {
        GUI.contentColor = corDoTexto;
        Scene scene = SceneManager.GetActiveScene();
        if(Elevador.subir){
            GUI.Label(new Rect(Screen.width / 2 - 40 - 12, 220, 600, 600), "Aperte E para entrar");                    
            if(Input.GetKey(trocar)){
                if(esse_elevador){
                    PlayerAnimation();   
                }
                    
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
