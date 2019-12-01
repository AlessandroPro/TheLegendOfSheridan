﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  this aspect allows the object to be pickedup by the 'other' gameobject 
//
public class Pickupable : MonoBehaviour
{
    public GameObject leftHandle;
    public GameObject rightHandle;
    public GameObject recipient;
    public bool equippable = true; // some items can be pickup up but not equipped (like a key)
    public bool ikOnAnchor;

    public Transform animAnchor;
    public AnimationClip[] pickupClips;
    public float animSpeedMultiplier;

    public EquipAnchor.EquipAnchors anchor;

    public void OnAvailable(GameObject other)
    {
        recipient = other;
        ItemEquipper itemEquipper = recipient.GetComponent<ItemEquipper>();
        if (itemEquipper)
        {
           itemEquipper.availableItem = this;
        }
    }

    public void OnUnavailable(GameObject other)
    {
        ItemEquipper itemEquipper = recipient.GetComponent<ItemEquipper>();
        if (itemEquipper)
        {
           itemEquipper.availableItem = null;
        }
        recipient = null;
    }

    public void OnPickUp()
    {

    }

    public void OnDrop()
    {

    }

    public void SetToAnchor(List<EquipAnchor> anchors)
    {
        foreach (EquipAnchor equipAnchor in anchors)
        {
            if (anchor == equipAnchor.anchor)
            {
                GetComponent<Anchorable>().SetTarget(equipAnchor.transform);
                break;
            }
        }
    }
}
