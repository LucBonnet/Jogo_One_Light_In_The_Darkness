using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SombraControler : MonoBehaviour
{

    public float speed = 2f;
    private GameObject Player;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = Player.transform.position;

        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, playerPos, step);

        if(playerPos.x < transform.position.x) {
            spr.flipX = false;
        } else {
            spr.flipX = true;
        }
    }
}
