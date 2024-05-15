using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IDataPersistence
{   
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode camAttack = KeyCode.Space;
    public KeyCode run = KeyCode.LeftShift;
    private float speed = 3f;
    public float boundX = 0f;
    private Rigidbody2D rb2d;
    private Vector2 moveDirection;
    private Animator anime;
    int count = 0;
    public bool cancado;
    public GameObject cam;
    public int hasCam = 1; // 0 - não tem camera, 1 - camera 1, 2 - camera 2
    public static bool chavecamera = false; // false - não tem chave, true - tem chave
    public static bool chaveprototipo = false;  // false - não tem chave, true - tem chave

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

    void OnTriggerEnter2D(Collider2D hitinfo) {
        if(hitinfo.CompareTag("sombraI") || hitinfo.CompareTag("sombraII") || hitinfo.CompareTag("sombraIII")) {
            hitinfo.SendMessage("StartDamage", 0f, SendMessageOptions.RequireReceiver);
        }
    }

    void OnTriggerExit2D(Collider2D hitinfo) {
        if(hitinfo.CompareTag("sombraI") || hitinfo.CompareTag("sombraII") || hitinfo.CompareTag("sombraIII")) {
            if(hitinfo) {
                hitinfo.SendMessage("StopDamage", 0f, SendMessageOptions.RequireReceiver);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal,vertical);         

        if(Input.GetKeyDown(camAttack) && hasCam > 0) {
            cam.SetActive(true);
            cam.SendMessage("SetCamType", hasCam, SendMessageOptions.RequireReceiver);
        }
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
                Stamina.stamina -= 1f;
            }
              
        else{
            Stamina.stamina += 0.1f;
            speed = 3f; 
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

    public void LoadData(GameData data) {
        transform.position = data.playerPosistion;
        hasCam = data.playerHasCamera;
        Stamina.stamina = data.stamina;
        Stamina.maxStamina = data.maxStamina;
    }

    public void SaveData(ref GameData data) {
        Debug.Log("Stamina: " + Stamina.stamina + "\nMaxStamina: " + Stamina.maxStamina);
        
        data.playerPosistion = transform.position;
        data.playerHasCamera = hasCam;
        data.stamina = Stamina.stamina;
        data.maxStamina = Stamina.maxStamina;
    }
}
