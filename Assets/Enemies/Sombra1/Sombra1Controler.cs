using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SombraControler : MonoBehaviour
{

    public float speed = 2f;
    private GameObject Player;
    private SpriteRenderer spr;

    private bool attacking;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        spr = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
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
    }
}
