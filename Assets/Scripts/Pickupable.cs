using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//
//  this aspect allows the object to be pickedup by the 'other' gameobject 
//
[System.Serializable]
public class UseEvent : UnityEvent<GameObject> { }

public class Pickupable : MonoBehaviour
{
    public GameObject leftHandle;
    public GameObject rightHandle;
    public GameObject recipient;
    public bool equippable = true; // some items can be pickup up but not equipped (like a key)
    public bool ikOnAnchor;

    public Transform animAnchor;
    public AnimationClip[] pickupClips;
    public AnimationClip useClip;
    public float animSpeedMultiplier;

    public EquipAnchor.EquipAnchors anchor;

    public List<UseEvent> useEvents;

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

    public void OnUseEvent(int eventIndex, GameObject sender)
    {
        if(eventIndex < useEvents.Count)
        {
            useEvents[eventIndex].Invoke((GameObject) sender);
        }
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
