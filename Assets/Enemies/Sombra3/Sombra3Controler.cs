using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombra3Controler : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    private void GenerateGuid() {
        id = System.Guid.NewGuid().ToString();
    }
    public float speed = 2f;
    private GameObject Player;
    private SpriteRenderer spr;
    private Animator anim;
    private Vector3 initialPosition;
    public float visao = 7f;
    public float life = 100;
    private bool damage = false;
    private float initialLife;
    private float blockedLife;
    private float currentLife;  
    private float initialSpeed;
    private float timerDamage = 0.0f;
    private float waitTimeDamage = 0.6f;
    private bool derrotado = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        initialPosition = transform.position;
        initialSpeed = speed;
        initialLife = life;
        currentLife = initialLife;
        blockedLife = initialLife;
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
        if(derrotado) {
            Destroy(gameObject);
            return;
        }

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
            anim.Play("andando");
            if(targetPos.x < transform.position.x) {
                spr.flipX = false;
            } else {
                spr.flipX = true;
            }
        } else {
            anim.Play("parado");
        }

        if(damage) {
            timerDamage += Time.deltaTime;
            if (timerDamage >= waitTimeDamage){
                life = Mathf.Max(life - 1, 0);
                timerDamage = 0.0f;
                speed = Mathf.Max(speed - 0.01f, 0);

                if(life <= 0) {
                    derrotado = true;
                }
            }
        }
        
        spr.material.color = new Color(1f, 1f, 1f, Mathf.Min(Mathf.Max(life*1f/initialLife, 0.3f) + 0.2f, 1f));
    }

     public void LoadData(GameData data) {
        if(id.Equals("")) return;

        data.sombrasDerrotadas.TryGetValue(id, out derrotado);
        if(derrotado) {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data) {
        if(id == "") return;
        
        if(data.sombrasDerrotadas.ContainsKey(id)) {
            data.sombrasDerrotadas.Remove(id);
        }
        
        data.sombrasDerrotadas.Add(id, derrotado);
    }
}
