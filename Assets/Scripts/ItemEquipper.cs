using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipAnchor
{
    public enum EquipAnchors
    {
        LeftHand,
        RightHand,
        LeftFoot,
        RightFoot,
        LeftWaist,
        RightWaist,
        Belly
    };

    public EquipAnchors anchor;
    public Transform transform;
}

public class ItemEquipper : MonoBehaviour
{
    public Pickupable availableItem; // Item that can be picked up
    public Pickupable equippedItem;  // Currently equipped item

    private Controllable controllable;

    public List<EquipAnchor> equipAnchors;

    private Animator anim;
    private AnimatorOverrideController animOverrider;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controllable = GetComponent<Controllable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!controllable.lockInteraction)
        {
            if(Input.GetButtonDown("Circle Button"))
            {
                if (equippedItem)
                {
                    UseItem();
                }
                else if (availableItem)
                {
                    PickupItem();
                }
            }
        }
    }

    void PickupItem()
    {
        Pickupable pickedItem = availableItem;
        availableItem = null;

        AnimationClip[] pickupClips = pickedItem.pickupClips;

        if (anim)
        {
            animOverrider = new AnimatorOverrideController(anim.runtimeAnimatorController);
            anim.runtimeAnimatorController = animOverrider;
        }
        // Override the pickup animations with the animations given by the Pickupable, if any
        if (animOverrider && pickupClips.Length == 2)
        {
            animOverrider["CrouchDown"] = pickupClips[0];
            animOverrider["CrouchUp"] = pickupClips[1];
        }
        anim.SetFloat("AnimSpeed", pickedItem.animSpeedMultiplier);
        anim.SetTrigger("Pickup");


        equippedItem = pickedItem;
    }

    void UseItem()
    {
        anim.SetTrigger("Use");
    }

    void dropItem()
    {

    }

    //void pickUpItem()
    //{
    //    if(itemIter < availableItems.Count)
    //    {
    //        anim.SetBool("hasWeapon", false);
    //        PlayerController player = GetComponent<PlayerController>();
    //        grabbedObject = availableItems[itemIter];
    //        Pickupable pickupable = grabbedObject.GetComponent<Pickupable>();
    //        if (pickupable)
    //        {
    //            // change this to be left handle or right handle depending on which is null, and therefore change the IKGoal
    //            ikc.trackObjRH = pickupable.rightHandle;
    //            ikc.trackObjLH = pickupable.leftHandle;
    //            equippedItems.Add(availableItems[itemIter]);
    //            pickupable.OnPickUp();
    //            if(player.weapon)
    //            {
    //                player.dropWeapon();
    //            }
    //            if(grabbedObject.GetComponent<Weapon>())
    //            {
    //                if(player)
    //                {
    //                    player.weapon = grabbedObject.GetComponent<Pickupable>();
    //                    anim.SetBool("hasWeapon", true);
    //                } 
    //            }
    //        }
    //        itemIter++;
    //        if(itemIter >= availableItems.Count)
    //        {
    //            clearAvailableItems();
    //        }
    //    }
    //}

    void anchorPickup()
    {
        if (equippedItem)
        {
            equippedItem.SetToAnchor(equipAnchors);
        }
    }

    void resetIK()
    {

    }
}
