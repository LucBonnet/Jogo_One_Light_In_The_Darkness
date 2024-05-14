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


    // Start is called before the first frame update
    void Start()
    {
        GameObject play = GameObject.FindGameObjectWithTag("Player");

        // Obtém a referência ao script do jogador
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
        if(Descer.descer){
            if(scene.name == "Terreo" || scene.name == "Terreo 1"){
                GUI.Label(new Rect(Screen.width / 2 - 40 - 12, 50, 600, 600), "Aperte E para sair");
            }
            else{
                GUI.Label(new Rect(Screen.width / 2 - 245 - 12, 220, 600, 600), "Aperte E para descer");
            }
            
            if(Input.GetKey(trocar)){
                if(scene.name == "Terreo" || scene.name == "Terreo 1"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("Entrada");
                } 
                if(scene.name == "1Andar"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("Terreo 1");
                    // player.transform.position = new Vector3(1.66f, 0.02f,0f);
                }   
                if(scene.name == "2Andar"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("1Andar");
                }
                if(scene.name == "3Andar"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("2Andar");
                } 
                if(scene.name == "4Andar"){
                    DataPersistenceManager.instance.SaveGame();                
                    SceneManager.LoadScene("3Andar");
                }   
                if(scene.name == "5Andar"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("4Andar");
                }     
            }
        } 
    }
    // Update is called once per frame
    void Update()
    {        
    }
}
