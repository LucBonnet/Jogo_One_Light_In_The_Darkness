using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chave_camera : MonoBehaviour
{

    public GUISkin layout;
    public bool subir = false;
    public Color corDoTexto = Color.red;
    public KeyCode trocar = KeyCode.E;
    public Sprite novoSprite;
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
        if(subir && !PlayerControl.chavecamera){
            GUI.Label(new Rect(Screen.width / 2 - 40 - 12, 220, 600, 600), "Aperte E para pegar");                    
            if(Input.GetKey(trocar)){       
                GetComponent<SpriteRenderer>().sprite = novoSprite; 
                PlayerControl.chavecamera = true;                                       
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
