using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Descer : MonoBehaviour
{
    public GUISkin layout;
    public static bool descer = false;
    public KeyCode trocar = KeyCode.E;
    public Color corDoTexto = Color.red; // Defina a cor desejada aqui
    public PlayerControl player; // Referência ao script do jogador
    private Vector2 posicaoEscada = new Vector2(1.34f, -0.11f);

    void Start()
    {
        GameObject play = GameObject.FindGameObjectWithTag("Player");
        player = play.GetComponent<PlayerControl>();

    }
    void OnTriggerEnter2D (Collider2D hitInfo) {     
        if (hitInfo.CompareTag("Player")){
            descer = true;               
        } 
    }
    void OnTriggerExit2D (Collider2D hitInfo) {      
        descer = false;                       
    }
    void OnGUI () {
        GUI.contentColor = corDoTexto;
        Scene scene = SceneManager.GetActiveScene();
        if(descer){
            if(scene.name == "Terreo"){
                GUI.Label(new Rect(Screen.width / 2 - 40 - 12, 50, 600, 600), "Aperte E para sair");
            }
            else{
                GUI.Label(new Rect(Screen.width / 2 - 245 - 12, 220, 600, 600), "Aperte E para descer");
            }
            
            if(Input.GetKey(trocar)){
                if(scene.name == "Terreo"){
                    player.SendMessage("SetPosition", new Vector2(7.66f, 19.92f), SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("Entrada");
                } 
                if(scene.name == "1Andar"){
                    player.SendMessage("SetPosition", posicaoEscada, SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("Terreo");
                }   
                if(scene.name == "2Andar"){
                    player.SendMessage("SetPosition", posicaoEscada, SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("1Andar");
                }
                if(scene.name == "3Andar"){
                    player.SendMessage("SetPosition", posicaoEscada, SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("2Andar");
                } 
                if(scene.name == "4Andar"){
                    player.SendMessage("SetPosition", posicaoEscada, SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();                
                    SceneManager.LoadScene("3Andar");
                }   
                if(scene.name == "5Andar"){
                    player.SendMessage("SetPosition", posicaoEscada, SendMessageOptions.RequireReceiver);
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("4Andar");
                }     
            }
        } 
    }
}
