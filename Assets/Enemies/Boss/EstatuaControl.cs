using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EstatuaControl : MonoBehaviour
{
    public Animator animBoss;
    public float life;
    public Light2D olhoE;
    public Light2D olhoD;
    private const float MAX_LIFE = 1000f;
    private float intensidade;
    private bool damage = false;
    private float timerDamage = 0.0f;
    private float waitTimeDamage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        intensidade = 0.5f;
        life = MAX_LIFE;
    }
    public void StartDamage() {
        damage = true;
    }

    public void StopDamage() {
        damage = false;
    }   

    public void TakeDamage(float d) {
        animBoss.SetTrigger("damage");
        life -= d;
    }

    private void Derrotado() {
        Destroy(gameObject);
        animBoss.Play("morrendo");
    }

    float Map(float x, float a1, float a2, float b1, float b2)
    {
        return b1 + (x-a1)*(b2-b1)/(a2-a1);
    }

    // Update is called once per frame
    void Update()
    {
        if(damage) {
            timerDamage += Time.deltaTime;
            if (timerDamage >= waitTimeDamage){
                life = Mathf.Max(life - 1, 0);
                animBoss.SetTrigger("damage");
                timerDamage = 0.0f;
                if(life <= 0) {
                    Derrotado();
                }
            }
        }

        intensidade = Map(life, MAX_LIFE, 0f, 0.5f, 30f);

        olhoE.intensity = intensidade;
        olhoD.intensity = intensidade;
    }
}
