using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchorable : MonoBehaviour
{
    public Transform TargetAnchor;
    public float kh; //springynes coeff
    public bool isAnchored = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HysteresisUpdate();
    }

    public void SetTarget(Transform target)
    {
        TargetAnchor = target;
    }

    public void HysteresisUpdate()
    {
        if (TargetAnchor != null)// && !isAnchored)
        {
            Vector3 diff = TargetAnchor.position - this.transform.position;
            //this.transform.position += kh * (diff);
            transform.position = TargetAnchor.position; 
            transform.rotation = TargetAnchor.rotation;
        }
    }
}
