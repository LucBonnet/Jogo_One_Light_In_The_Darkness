using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform target;
    private Camera cam;
    public SpriteRenderer[] cenarios;
    private float boundMinX, boundMaxX, boundMinY, boundMaxY;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        boundMinY = cenarios[0].bounds.min.y;
        boundMaxY = cenarios[0].bounds.max.y;
        boundMinX = cenarios[0].bounds.min.x;
        boundMaxX = cenarios[0].bounds.max.x;
        for(int i = 0; i < cenarios.Length; i++) {
            float cMinX = cenarios[i].bounds.min.x;
            float cMaxX = cenarios[i].bounds.max.x;
            float cMinY = cenarios[i].bounds.min.y;
            float cMaxY = cenarios[i].bounds.max.y;

            if(cMinY < boundMinY) boundMinY = cMinY;
            if(cMaxY > boundMaxY) boundMaxY = cMaxY;

            if(cMinX < boundMinX) boundMinX = cMinX;
            if(cMaxX > boundMaxX) boundMaxX = cMaxX;
        }
    	Debug.Log("Final: " + boundMinY + ", " + boundMaxY);
    	Debug.Log("Final: " + boundMinX + ", " + boundMaxX);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;

        Vector3 newPosition = target.position;
        newPosition.z = -20;
        if(target.position.x + halfWidth > boundMaxX) {
            newPosition.x = boundMaxX - halfWidth;
        }

        if(target.position.x - halfWidth < boundMinX) {
            newPosition.x = boundMinX + halfWidth;
        }

        if(target.position.y + halfHeight > boundMaxY) {
            newPosition.y = boundMaxY - halfHeight;
        }

        if(target.position.y - halfHeight < boundMinY) {
            newPosition.y = boundMinY + halfHeight;
        }

        transform.position = newPosition;
    }
}
