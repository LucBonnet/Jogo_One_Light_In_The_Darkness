using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCenarioControler : MonoBehaviour
{
    private SpriteRenderer spr;
    private CircleCollider2D cc2d;
    private PolygonCollider2D pc2d;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        cc2d = GetComponent<CircleCollider2D>();
        pc2d = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.gameObject.TryGetComponent(out SpriteRenderer sp)) return;
        
        float otherY = sp.bounds.min.y;
        float objectY = spr.bounds.min.y - 0.5f;
        if(otherY > objectY) {
            // o player passa por tras
            if(cc2d != null) {
                cc2d.enabled = true;
            }
            if(pc2d != null) {
                pc2d.enabled = true;
            }
            spr.sortingLayerName = "cima";
        } else {
            // o player passa pela frente
            if(cc2d != null) {
                cc2d.enabled = false;
            }   
            if(pc2d != null) {
                pc2d.enabled = false;
            }
            spr.sortingLayerName = "player";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
