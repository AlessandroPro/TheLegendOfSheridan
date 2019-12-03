using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void release()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
    }
}
