using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevador : MonoBehaviour
{
   public GUISkin layout;
    public bool subir = false;
    public bool aberto = false;
    public Color corDoTexto = Color.red;
    private Animator anime;
    private Collider2D colliderInimigo;
    public KeyCode trocar = KeyCode.E;
    
    void Start()
    {
       anime = GetComponent<Animator>();
       
    }

    public void PlayerAnimation(string animationName){
        anime.Play(animationName);
    }
    void OnTriggerEnter2D (Collider2D hitInfo) {           
        if (hitInfo.CompareTag("Player")){
           	subir = true; 
        } 
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if(aberto){
            Debug.Log("OnTriggerEnter2D acionado!");  
    	    if(coll.collider.CompareTag("Player")){
			StartCoroutine(WaitAndPrint(0.5f));
    	}  
        }
        
	}

    IEnumerator WaitAndPrint(float waitTime)
    {
        Debug.Log("Esperando " + waitTime + " segundos...");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Tempo de espera concluído. Carregando cena 'Elevador'...");
        SceneManager.LoadScene("Elevador");

    }
    void OnTriggerExit2D (Collider2D hitInfo) {      
           	subir = false;
            if(aberto == true){
               PlayerAnimation("porta_elevador_fechando");  
            }   
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false ; 
            aberto = false;                      
    }
    void OnGUI () {
        GUI.contentColor = corDoTexto;
        Scene scene = SceneManager.GetActiveScene();
        if(subir){
            GUI.Label(new Rect(Screen.width / 2 - 40 - 12, 220, 600, 600), "Aperte E para entrar");                    
            if(Input.GetKey(trocar)){               
                PlayerAnimation("porta_elevador"); 
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true ;
                aberto = true;                       
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
