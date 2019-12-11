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
        Destroy(this.gameObject, 10);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>())
        {
           Destroy(this.gameObject);
        }
    }
}
