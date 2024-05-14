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


    // Start is called before the first frame update
    void Start()
    {
       
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
        if(Subir.subir){
            if(scene.name == "Entrada"){
                GUI.Label(new Rect(Screen.width / 2 - 40 - 12, 220, 600, 600), "Aperte E para entrar");
            }
            else{
               GUI.Label(new Rect(Screen.width / 2 - 245 - 12, 220, 600, 600), "Aperte E para subir");
            }
            
            if(Input.GetKey(trocar)){
                if(scene.name == "Entrada"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("Terreo");
                }
                if(scene.name == "Terreo" || scene.name == "Terreo 1"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("1Andar");
                }
                if(scene.name == "1Andar"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("2Andar");
                }   
                if(scene.name == "2Andar"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("3Andar");
                }
                if(scene.name == "3Andar"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("4Andar");
                }
                if(scene.name == "4Andar"){
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("5Andar");
                }           
            }
        }
    }
    // Update is called once per frame
    void Update()
    {        
    }
}
