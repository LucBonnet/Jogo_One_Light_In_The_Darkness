using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    private float time = 0f;
    private float waitTime;

    public GameObject sombra1;
    public GameObject sombra2;

    private Animator anim;

    private float GenerateTime() {
        return Random.Range(500, 700) / 100f;
    }
    
    void Start()
    {
        anim = GetComponent<Animator>();
        waitTime = GenerateTime();
    }

    void Invocacao() {
        int type = Random.Range(0, 100);
        GameObject sombra;
        if (type > 30) {
            sombra = sombra1;
        } else {
            sombra = sombra2;
        }

        anim.SetTrigger("invoke1");
        Vector2 position = transform.position;
        Debug.Log(sombra.name);
        Instantiate(sombra, position, Quaternion.identity);
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > waitTime) {
            time = 0f;
            waitTime = GenerateTime();
            Invocacao();
        }
    }
}
