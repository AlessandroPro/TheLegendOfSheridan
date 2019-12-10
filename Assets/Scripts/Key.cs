using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void getKey(GameObject entity)
    //{
    //    //if (arrowPrefab && arrow == null)
    //   // {
    //        var eqiupper = entity.GetComponent<ItemEquipper>();
    //        if (eqiupper)
    //        {
    //            foreach (var equipAnchor in eqiupper.equipAnchors)
    //            {
    //                if (EquipAnchor.EquipAnchors.LeftHand == equipAnchor.anchor)
    //                {
    //                    var anchorable = GetComponent<Anchorable>();
    //                    if(anchorable)
    //                    {
    //                        anchorable.SetTarget(equipAnchor.transform);
    //                    }
    //                    break;
    //                }
    //            }
    //        }
    //   // }
    //}

    public void getKey(GameObject entity)
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    public void stopKey(GameObject entity)
    {
        GetComponent<BoxCollider>().enabled = false;
    }
}
