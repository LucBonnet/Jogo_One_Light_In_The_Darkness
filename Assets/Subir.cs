using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Subir : MonoBehaviour
{
    public GUISkin layout;
    public static bool subir = false;
    public Color corDoTexto = Color.red; // Defina a cor desejada aqui
    public KeyCode trocar = KeyCode.E;
    private GameObject player;

     private Vector2 posicaoEscada = new(1.34f, -2.37f);


    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
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
        if(subir){
            if(scene.name == "Entrada"){
                GUI.Label(new Rect(Screen.width / 2 - 40 - 12, 220, 600, 600), "Aperte E para entrar");
            }
            else{
               GUI.Label(new Rect(Screen.width / 2 - 245 - 12, 220, 600, 600), "Aperte E para subir");
            }
            
            if(Input.GetKey(trocar)){
                if(scene.name == "Entrada"){
                    player.SendMessage("SetPosition", new Vector2(5.08f, -4.31f), SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("Terreo");
                }
                if(scene.name == "Terreo"){
                    player.SendMessage("SetPosition", posicaoEscada, SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("1Andar");
                }
                if(scene.name == "1Andar"){
                    player.SendMessage("SetPosition", posicaoEscada, SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("2Andar");
                }   
                if(scene.name == "2Andar"){
                    player.SendMessage("SetPosition", posicaoEscada, SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("3Andar");
                }
                if(scene.name == "3Andar"){
                    player.SendMessage("SetPosition", posicaoEscada, SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("4Andar");
                }
            }
        }
    }
}
