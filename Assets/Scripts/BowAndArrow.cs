using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAndArrow : MonoBehaviour
{
    public GameObject arrowPrefab;
    private GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Instantiate an arrow in the right hand of the entity 
    public void getArrow(GameObject entity)
    {
        if(arrowPrefab && arrow == null)
        {
            var eqiupper = entity.GetComponent<ItemEquipper>();
            if(eqiupper)
            {
                foreach (var equipAnchor in eqiupper.equipAnchors)
                {
                    if (EquipAnchor.EquipAnchors.RightHand == equipAnchor.anchor)
                    {
                        arrow = Instantiate(arrowPrefab, equipAnchor.transform.position, equipAnchor.transform.rotation);
                        arrow.transform.parent = equipAnchor.transform;
                        break;
                    }
                }
            }
        }
    }

    public void ReleaseArrow(GameObject entity)
    {
        if (arrow != null)
        {
            arrow.GetComponent<Arrow>().release();
            arrow = null;
        }
    }
}
