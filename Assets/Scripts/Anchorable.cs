using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchorable : MonoBehaviour
{
    public Transform TargetAnchor;
    public IKControl ikc;
    public bool ikOnAnchor = false;
    public float kh; //springyness coeff
    public bool snapToTarget = false;

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
        //snapToTarget = false;
    }

    public void HysteresisUpdate()
    {
        if (TargetAnchor != null)
        {
            if (snapToTarget)
            {
                transform.position = TargetAnchor.position;
                transform.rotation = TargetAnchor.rotation;
            }
            else
            {
                Vector3 diff = TargetAnchor.position - this.transform.position;
                this.transform.position += kh * (diff);
                transform.rotation = TargetAnchor.rotation;

                // Stick to the anchor indefinitely once close enough
                if(diff.magnitude < 0.1f)
                {
                    SnapToTarget();
                }
            }
        }
    }

    public void SnapToTarget()
    {
        snapToTarget = true;
        if (!ikOnAnchor && ikc)
        {
            ikc.weight = 0;
        }
        else
        {
            ikc.weight = 1;
        }
    }
}
