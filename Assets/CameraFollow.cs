using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float xDistance = 5.0f;
    public float yDistance = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraUpdate();
    }

    void CameraUpdate()
    {
        Vector3 desiredPosition = target.position;
        desiredPosition.x += xDistance;
        desiredPosition.y += yDistance;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.5f);
    }
}
