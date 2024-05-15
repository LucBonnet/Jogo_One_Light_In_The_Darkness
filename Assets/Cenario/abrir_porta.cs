using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrir_porta : MonoBehaviour
{

    public GUISkin layout;
    public bool subir = false;
    public bool aberto = false;
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
        if(subir  && !aberto){
            GUI.Label(new Rect(Screen.width / 2 - 40 - 12, 220, 600, 600), "Aperte E para entrar");                    
            if(Input.GetKey(trocar) && PlayerControl.chavecamera){       
                GetComponent<SpriteRenderer>().sprite = novoSprite;        
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;   
                aberto = true;                               
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
