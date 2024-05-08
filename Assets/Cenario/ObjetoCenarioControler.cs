using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCenarioControler : MonoBehaviour
{
    private SpriteRenderer spr;
    private BoxCollider2D[] bcs2d;
    private Vector2[] bc2dInitialOffsets;
    public GameObject[] sombras;
    private Vector2[] sombrasPosition;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        bcs2d = GetComponents<BoxCollider2D>();
        bc2dInitialOffsets = new Vector2[bcs2d.Length];
        sombrasPosition = new Vector2[sombras.Length];

        for(int i = 0; i < bcs2d.Length; i++) {
            bc2dInitialOffsets[i] = bcs2d[i].offset;
        }

        for(int i = 0; i < sombras.Length; i++) {
            sombrasPosition[i] = sombras[i].transform.position;
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
                bcs2d[i].enabled = true;
                bcs2d[i].offset = new Vector2(bc2dInitialOffsets[i].x, bc2dInitialOffsets[i].y);
            }

            for(int i = 0; i < sombras.Length; i++) {
                sombras[i].transform.position = new Vector2(sombrasPosition[i].x, sombrasPosition[i].y);
            }

            spr.sortingLayerName = "cima";
        } else {
            // o player passa pela frente
            if(otherMaxY < objectY) {
                for(int i = 0; i < bcs2d.Length; i++) {
                    bcs2d[i].enabled = false;
                    bcs2d[i].offset = new Vector2(bc2dInitialOffsets[i].x, bc2dInitialOffsets[i].y);
                }

                for(int i = 0; i < sombras.Length; i++) {
                    sombras[i].transform.position = new Vector2(sombrasPosition[i].x, sombrasPosition[i].y);
                }
            } else {
                float offset = otherMaxY - otherMinY - 0.5f;
                for(int i = 0; i < bcs2d.Length; i++) {
                    bcs2d[i].offset = new Vector2(bc2dInitialOffsets[i].x, bc2dInitialOffsets[i].y + offset);
                    bcs2d[i].enabled = true;
                }

                for(int i = 0; i < sombras.Length; i++) {
                    sombras[i].transform.position = new Vector2(sombrasPosition[i].x, sombrasPosition[i].y + offset);
                }
            }
            spr.sortingLayerName = "player";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        for(int i = 0; i < bcs2d.Length; i++) {
            bcs2d[i].enabled = false;
            bcs2d[i].offset = new Vector2(bc2dInitialOffsets[i].x, bc2dInitialOffsets[i].y);
        }

        for(int i = 0; i < sombras.Length; i++) {
            sombras[i].transform.position = new Vector2(sombrasPosition[i].x, sombrasPosition[i].y);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
