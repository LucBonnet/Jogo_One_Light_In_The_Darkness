using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCenarioControler : MonoBehaviour
{
    private SpriteRenderer spr;
    private BoxCollider2D bc2d;
    private Vector2 bc2dInitialOffset;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();

        bc2dInitialOffset = bc2d.offset;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.gameObject.TryGetComponent(out SpriteRenderer sp)) return;
        
        float otherMinY = sp.bounds.min.y;
        float otherMaxY = sp.bounds.max.y;
        float objectY = spr.bounds.min.y - 0.5f;
        if(otherMinY > objectY) {
            // o player passa por tras
            bc2d.enabled = true;
            bc2d.offset = new Vector2(bc2dInitialOffset.x, bc2dInitialOffset.y);
            spr.sortingLayerName = "cima";
        } else {
            // o player passa pela frente
            if(otherMaxY < objectY) {
                bc2d.enabled = false;
                bc2d.offset = new Vector2(bc2dInitialOffset.x, bc2dInitialOffset.y);
            } else {
                float offset = otherMaxY - otherMinY - 0.2f;
                bc2d.offset = new Vector2(bc2dInitialOffset.x, bc2dInitialOffset.y + offset);
                bc2d.enabled = true;
            }
            spr.sortingLayerName = "player";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        bc2d.enabled = false;
        bc2d.offset = new Vector2(bc2dInitialOffset.x, bc2dInitialOffset.y);
        spr.sortingLayerName = "player";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
