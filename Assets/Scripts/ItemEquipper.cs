//using System.Collections.Generic;
//using UnityEngine;

//[System.Serializable]
//public class EquipAnchor
//{
//    public enum EquipAnchors
//    {
//        LeftHand,
//        RightHand,
//        LeftFoot,
//        RightFoot,
//        LeftWaist,
//        RightWaist,
//        Belly
//    };

//    public EquipAnchors anchor;
//    public Transform transform;
//}

//public class ItemEquipper : MonoBehaviour
//{
//    public Pickupable availableItem; // Item that can be picked up
//    public Pickupable equippedItem;  // Currently equipped item

//    private Controllable controllable;
//    private IKControl ikc;

//    public List<EquipAnchor> equipAnchors;

//    private Animator anim;
//    private AnimatorOverrideController animOverrider;


//    // Start is called before the first frame update
//    void Start()
//    {
//        anim = GetComponent<Animator>();
//        controllable = GetComponent<Controllable>();
//        ikc = GetComponent<IKControl>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (!controllable.lockInteraction)
//        {
//            if (Input.GetButtonDown("Circle Button"))
//            {
//                if (equippedItem)
//                {
//                    UseItem();
//                }
//                else if (availableItem)
//                {
//                    PickupItem();
//                }
//            }
//        }
//    }

//    // Starts the pickup animation and picks up the available item, if there is one
//    void PickupItem()
//    {
//        if (availableItem)
//        {
//            Pickupable pickedItem = availableItem;
//            availableItem = null;

//            AnimationClip[] pickupClips = pickedItem.pickupClips;

//            // Set the IK left hand and right hand to the left and right hands of the pickedItem
//            ikc.trackObjRH = pickedItem.rightHandle;
//            ikc.trackObjLH = pickedItem.leftHandle;

//            pickedItem.OnPickUp();

//            if (anim)
//            {
//                animOverrider = new AnimatorOverrideController(anim.runtimeAnimatorController);
//                anim.runtimeAnimatorController = animOverrider;
//            }
//            // Override the pickup animations with the animations given by the Pickupable, if any
//            if (animOverrider && pickupClips.Length == 2)
//            {
//                animOverrider["CrouchDown"] = pickupClips[0];
//                animOverrider["CrouchUp"] = pickupClips[1];
//            }
//            anim.SetFloat("AnimSpeed", pickedItem.animSpeedMultiplier);
//            anim.SetTrigger("Pickup");
//            ikc.getWeightFromAnim = true;

//            equippedItem = pickedItem;
//        }
//    }

//    void UseItem()
//    {
//        if (equippedItem)
//        {
//            AnimationClip useClip = equippedItem.useClip;

//            if (anim)
//            {
//                animOverrider = new AnimatorOverrideController(anim.runtimeAnimatorController);
//                anim.runtimeAnimatorController = animOverrider;
//            }
//            // Override the pickup animations with the animations given by the Pickupable, if any
//            if (animOverrider && useClip)
//            {
//                animOverrider["DrawArrow"] = useClip;
//            }
//            anim.SetTrigger("Use");
//        }
//    }

//    void dropItem()
//    {

//    }


//    void anchorPickup()
//    {
//        if (equippedItem)
//        {
//            equippedItem.SetToAnchor(equipAnchors);
//        }

//        ikc.getWeightFromAnim = false;

//        if(!equippedItem.ikOnAnchor)
//        {
//            ikc.weight = 0;
//        }
//    }

//    void sendUseEvent(int eventID)
//    {
//        if(equippedItem)
//        {
//            equippedItem.OnUseEvent(eventID, gameObject);
//        }
//    }

//    void resetIK()
//    {

//    }
//}


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

    public Queue<Pickupable> inventory;

    private Controllable controllable;
    private IKControl ikc;

    public List<EquipAnchor> equipAnchors;
    public EquipAnchor useAnchor;

    public Animator[] anims;
    //private AnimatorOverrideController animOverrider;



    // Start is called before the first frame update
    void Start()
    {
        controllable = GetComponent<Controllable>();
        ikc = GetComponent<IKControl>();
        inventory = new Queue<Pickupable>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(availableItem);
        if (!controllable.lockInteraction)
        {
            if (Input.GetButtonDown("Circle Button"))
            {
                if (availableItem)
                {
                    PickupItem();
                }
                else if (equippedItem)
                {
                    UseItem();
                }
            }
            else if(Input.GetButtonDown("Triangle Button"))
            {
                SwapItem();
            }
        }
    }

    // Starts the pickup animation and picks up the available item, if there is one
    void PickupItem()
    {
        if (availableItem)
        {
            holsterItem();

            Pickupable pickedItem = availableItem;
            availableItem = null;

            AnimationClip[] pickupClips = pickedItem.pickupClips;

            // Set the IK left hand and right hand to the left and right hands of the pickedItem
            ikc.trackObjRH = pickedItem.rightHandle;
            ikc.trackObjLH = pickedItem.leftHandle;

            pickedItem.OnPickUp();

            anims[1].gameObject.transform.position = gameObject.transform.position;
            anims[1].gameObject.transform.rotation = gameObject.transform.rotation;
            foreach (var anim in anims)
            {
                if(anim == anims[1])
                { break; }
                var animOverrider = new AnimatorOverrideController(anim.runtimeAnimatorController);
                anim.runtimeAnimatorController = animOverrider;

                // Override the pickup animations with the animations given by the Pickupable, if any
                if (animOverrider && pickupClips.Length == 2)
                {
                    animOverrider["CrouchDown"] = pickupClips[0];
                    animOverrider["CrouchUp"] = pickupClips[1];
                }
                anim.SetFloat("AnimSpeed", pickedItem.animSpeedMultiplier);
                anim.SetTrigger("Pickup");
            }

            ikc.getWeightFromAnim = true;

            equippedItem = pickedItem;
        }
    }



    void UseItem()
    {
        if (equippedItem)
        {
            AnimationClip useClip = equippedItem.useClip;

            anims[1].gameObject.transform.position = gameObject.transform.position;
            anims[1].gameObject.transform.rotation = gameObject.transform.rotation;

            foreach (var anim in anims)
            {
                var animOverrider = new AnimatorOverrideController(anim.runtimeAnimatorController);
                anim.runtimeAnimatorController = animOverrider;

                // Override the pickup animations with the animations given by the Pickupable, if any
                if (animOverrider && useClip)
                {
                    animOverrider["DrawArrow"] = useClip;
                }
                anim.SetTrigger("Use");
            }
        }
    }

    void holsterItem()
    {
        ikc.resetTrackers();
        if (equippedItem)
        {
            equippedItem.gameObject.SetActive(false);
            inventory.Enqueue(equippedItem);
            equippedItem = null;
        }
    }

    void SwapItem()
    {
        if (inventory.Count > 0)
        {
            holsterItem();
            availableItem = null;
            anims[1].gameObject.transform.position = gameObject.transform.position;
            anims[1].gameObject.transform.rotation = gameObject.transform.rotation;

            equippedItem = inventory.Dequeue();
            equippedItem.gameObject.SetActive(true);
            ikc.trackObjRH = equippedItem.rightHandle;
            ikc.trackObjLH = equippedItem.leftHandle;
            var anchorable = equippedItem.GetComponent<Anchorable>();
            if(anchorable)
            {
                anchorable.SnapToTarget();
            }
        }
    }


    void dropItem()
    {
        if(equippedItem)
        {
            equippedItem.OnDrop();
        }
    }


    void anchorPickup()
    {
        if (equippedItem)
        {
            equippedItem.SetToAnchor(equipAnchors);
        }

        ikc.getWeightFromAnim = false;
    }

    void sendUseEvent(int eventID)
    {
        if (equippedItem)
        {
            equippedItem.OnUseEvent(eventID, gameObject);
        }
    }
}