using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void release()
    {
        transform.parent = null;
        rb.AddForce(transform.forward * 7, ForceMode.Impulse);
        rb.useGravity = true;
    }
}
