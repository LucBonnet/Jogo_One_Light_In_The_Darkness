using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombra2Controler : MonoBehaviour
{
    public float speed = 2f;
    private float initialSpeed;
    private GameObject Player;
    private SpriteRenderer spr;
    private Animator anim;
    private Vector3 initialPosition;
    public float visao = 7f;
    public static float life = 30;
    private bool damage = false;
    private float initialLife = life;
    private float timerDamage = 0.0f;
    private float waitTimeDamage = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        initialPosition = transform.position;
        initialSpeed = speed;
    }

    public void StartDamage() {
        damage = true;
        Debug.Log(life);
    }

    public void StopDamage() {
        damage = false;
        life = initialLife;
        speed = speed = initialSpeed;;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        
        Vector3 targetPos = initialPosition;
        Vector3 playerPos = Player.transform.position;
        float distanceP = Vector3.Distance(playerPos, transform.position);

        if(distanceP < visao) {
            targetPos = playerPos;
        };
        float distance = Vector3.Distance(targetPos, transform.position);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

        if(distance > 0.1) {
            if(targetPos.x < transform.position.x) {
                anim.Play("AndandoEsquerda");
            } else if(targetPos.x > transform.position.x) {
                anim.Play("AndandoDireita");
            } else if(targetPos.y < transform.position.y) {
                anim.Play("AndandoBaixo");
            } else {
                anim.Play("AndandoCima");
            }
        } else {
            anim.Play("Parado");
        }

        if(damage) {
            timerDamage += Time.deltaTime;
            if (timerDamage >= waitTimeDamage){
                life = Mathf.Max(life - 1, 0);
                timerDamage = 0.0f;
                speed = Mathf.Max(speed - 0.01f, 0);

                if(life <= 0) {
                    Destroy(gameObject);
                }
            }
        }

        
        spr.material.color = new Color(1f, 1f, 1f, Mathf.Max(life*1f/initialLife, 0.3f));
    }
}
