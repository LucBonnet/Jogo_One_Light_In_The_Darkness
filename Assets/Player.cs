using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogador : MonoBehaviour
{   
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode run = KeyCode.LeftShift;
    private float speed = 3f;
    public float boundX = 0f;
    private Rigidbody2D rb2d;
    private Vector2 moveDirection;
    private Animator anime;
    int count = 0;
    public Stamina stamina; // Referência ao script do jogador
    public bool cancado;

    public GameObject lanterna;
    
    public void PlayerAnimation(string animationName){
        anime.Play(animationName);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Obtém a referência ao script do jogador
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log(other.name);
    }

    void OnTriggerEnter2D(Collider2D hitinfo) {
        
        if(hitinfo.CompareTag("sombraI") || hitinfo.CompareTag("sombraII")) {
            hitinfo.SendMessage("StartDamage", 0f, SendMessageOptions.RequireReceiver);
        }
    }

    void OnTriggerExit2D(Collider2D hitinfo) {
        if(hitinfo.CompareTag("sombraI") || hitinfo.CompareTag("sombraII")) {
            hitinfo.SendMessage("StopDamage", 0f, SendMessageOptions.RequireReceiver);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal,vertical);         
    }

    private void FixedUpdate()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lPos = lanterna.transform.position;
        float angle = (Mathf.Atan2(lPos.y - mousePos.y, lPos.x - mousePos.x) * Mathf.Rad2Deg) + 90;
        lanterna.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            if(Input.GetKey(run) && !cancado){
                speed = 5f;
                anime.speed = 1.6f;
                stamina.stamina = stamina.stamina -1f;
            }
              
        else{
            stamina.stamina = stamina.stamina +0.1f;
            speed =3f; 
            anime.speed = 1.0f;  
         
        }
        Vector2 movePosition = (speed * Time.fixedDeltaTime * moveDirection.normalized) + rb2d.position;
        rb2d.MovePosition(movePosition);

         if (Input.GetKey(moveUp)){             
            PlayerAnimation("idonback");       
            count =1;            
        }       
         if (Input.GetKey(moveDown)&& !Input.GetKey(moveUp) && !Input.GetKey(moveLeft)) {            
            PlayerAnimation("idonfront");   
            count =2;
        }
         if (Input.GetKey(moveLeft) && !Input.GetKey(moveUp) && !Input.GetKey(moveDown)) {            
            PlayerAnimation("andandoesquerda 0");
            count =3;
        }
        if (Input.GetKey(moveRight) && !Input.GetKey(moveUp) && !Input.GetKey(moveDown)) {            
            PlayerAnimation("andandodireita");
            count =4;
        }

          else{
            if(count == 1 && !Input.GetKey(moveUp)){
                PlayerAnimation("paradocostas");
            }
            if(count == 2 && !Input.GetKey(moveDown)){
                PlayerAnimation("paradofrente");
            }
            if(count == 3  && !Input.GetKey(moveLeft)){
                PlayerAnimation("paradoesquerda 0");
            }
            if(count == 4  && !Input.GetKey(moveRight)){
                PlayerAnimation("paradodireita");
            }
        }
    }
    }
