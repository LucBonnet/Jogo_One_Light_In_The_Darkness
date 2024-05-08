using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform target;
    private Camera cam;
    public SpriteRenderer cenario;
    private float boundMinX, boundMaxX, boundMinY, boundMaxY;
    private Boolean limit;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        boundMinX = cenario.bounds.min.x;
        boundMaxX = cenario.bounds.max.x;
        boundMinY = cenario.bounds.min.y;
        boundMaxY = cenario.bounds.max.y;
        limit = false;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        limit = false;
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
