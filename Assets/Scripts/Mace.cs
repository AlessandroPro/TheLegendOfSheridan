using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    private Transform defaultAnchor;
    private Anchorable anchorable;

    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        anchorable = GetComponent<Anchorable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void swapAnchors(GameObject entity)
    {
        if(anchorable)
        {
            if(anchorable.TargetAnchor)
            {
                defaultAnchor = anchorable.TargetAnchor;
            }

            var equipper = entity.GetComponent<ItemEquipper>();
            if (equipper)
            {
                if (equipper.useAnchor != null)
                {
                    anchorable.SetTarget(equipper.useAnchor.transform);
                }
            }
        }
    }

    public void setToDefaultAnchor(GameObject entity)
    {
        if (anchorable)
        {
            anchorable.SetTarget(defaultAnchor);
        }
    }
}
