using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SombraControler : MonoBehaviour
{

    public float speed = 2f;
    private float initialSpeed;
    private GameObject Player;
    private SpriteRenderer spr;

    private bool attacking;
    private Vector3 initialPosition;

    public float life = 10;
    private bool damage = false;
    private float initialLife;
    private float blockedLife;
    private float currentLife;
    private float timerDamage = 0.0f;
    private float waitTimeDamage = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        spr = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
        initialSpeed = speed;
        initialLife = life;
        currentLife = initialLife;
        blockedLife = initialLife;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            attacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            attacking = false;
        }
    }

    public void StartDamage() {
        damage = true;
    }

    public void StopDamage() {
        damage = false;
        life = initialLife;
        speed = initialSpeed;
    }

    public void TakeDamage(float d) {
        blockedLife = currentLife - d;
        life = blockedLife;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        
        Vector3 targetPos = initialPosition;

        if(attacking) {
            targetPos = Player.transform.position;
        };

        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

        if(targetPos.x < transform.position.x) {
            spr.flipX = false;
        } else {
            spr.flipX = true;
        }

        if(damage) {
            timerDamage += Time.deltaTime;
            if (timerDamage >= waitTimeDamage){
                life = Mathf.Max(life - 1, 0);
                timerDamage = 0.0f;
                speed = Mathf.Max(speed - 0.1f, 0);

                if(life <= 0) {
                    Destroy(gameObject);
                }
            }
        }
        
        spr.material.color = new Color(1f, 1f, 1f, Mathf.Max(life*1f/initialLife, 0.1f));
    }
}
