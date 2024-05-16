using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode camAttack = KeyCode.Space;
    public KeyCode run = KeyCode.LeftShift;

    private Animator anime;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    public void PlayerAnimation(string animationName){
        anime.Play(animationName);
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitAndPrint(float waitTime, string animacao)
    {
        Debug.Log("Esperando " + waitTime + " segundos...");
        yield return new WaitForSeconds(waitTime);
        PlayerAnimation(animacao); 


    }


    private void FixedUpdate()
    {
         if (Input.GetKey(moveUp) && count ==0){  
            PlayerAnimation("w_concluido"); 
            StartCoroutine(WaitAndPrint(1f, "s"));                 
            count =1;            
        }       
         if (Input.GetKey(moveDown) && count ==1) {  
            PlayerAnimation("s_concluido"); 
            StartCoroutine(WaitAndPrint(1f, "a"));          
            count =2;
        }
         if (Input.GetKey(moveLeft) && count ==2) { 
            PlayerAnimation("a_concluido");  
            StartCoroutine(WaitAndPrint(1f, "d"));          
            count =3;
        }
        if (Input.GetKey(moveRight) && count ==3) {
            PlayerAnimation("d_concluido");  
            StartCoroutine(WaitAndPrint(1f, "shift"));            
            count =4;
        }
    }
}
