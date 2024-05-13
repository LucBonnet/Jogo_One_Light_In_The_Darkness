using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCenarioControler : MonoBehaviour
{
    private SpriteRenderer spr;
    private BoxCollider2D[] bcs2d;
    private Vector2[] bc2dInitialOffsets;
    private bool bc2dEnabled = true;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        bcs2d = GetComponents<BoxCollider2D>();
        bc2dInitialOffsets = new Vector2[bcs2d.Length];

        for(int i = 0; i < bcs2d.Length; i++) {
            bc2dInitialOffsets[i] = bcs2d[i].offset;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(!bc2dEnabled) {
            for(int i = 0; i < bcs2d.Length; i++) {
                Physics2D.IgnoreCollision(other.collider, bcs2d[i]);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.gameObject.TryGetComponent(out SpriteRenderer sp)) return;
        
        float otherMinY = sp.bounds.min.y;
        float otherMaxY = sp.bounds.max.y;
        float objectY = spr.bounds.min.y - 0.5f;
        if(otherMinY > objectY) {
            // o player passa por tras
            for(int i = 0; i < bcs2d.Length; i++) {
                bc2dEnabled = true;
                bcs2d[i].offset = new Vector2(bc2dInitialOffsets[i].x, bc2dInitialOffsets[i].y);
            }

            spr.sortingLayerName = "cima";
        } else {
            // o player passa pela frente
            if(otherMaxY < objectY) {
                for(int i = 0; i < bcs2d.Length; i++) {
                    bc2dEnabled = false;
                    bcs2d[i].offset = new Vector2(bc2dInitialOffsets[i].x, bc2dInitialOffsets[i].y);
                }
            } else {
                float offset = otherMaxY - otherMinY - 0.5f;
                for(int i = 0; i < bcs2d.Length; i++) {
                    bc2dEnabled = true;
                    bcs2d[i].offset = new Vector2(bc2dInitialOffsets[i].x, bc2dInitialOffsets[i].y + offset);
                }
            }
            spr.sortingLayerName = "player";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        for(int i = 0; i < bcs2d.Length; i++) {
            bc2dEnabled = false;
            bcs2d[i].offset = new Vector2(bc2dInitialOffsets[i].x, bc2dInitialOffsets[i].y);
        }

        if(!other.gameObject.TryGetComponent(out SpriteRenderer sp)) return;
         
        float otherMinY = sp.bounds.min.y + 0.5f;
        float objectY = spr.bounds.max.y;
        if(otherMinY < objectY) {
            spr.sortingLayerName = "player";
        } else {
            spr.sortingLayerName = "cima";
        }
    }
}
