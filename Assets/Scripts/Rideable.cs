using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rideable : MonoBehaviour
{
    public GameObject leftHandle;
    public GameObject rightHandle;
    public GameObject leftPedal;
    public GameObject rightPedal;
    public GameObject lookAt;
    public Transform animStart;

    public AnimationClip[] mountClips;
    public bool mirrorMount = false;

    public GameObject recipient;
    private IKControl ikc;
    private Controllable controllable;

    public CanvasBehaviour prompt;

    // Start is called before the first frame update
    void Start()
    {
        controllable = GetComponent<Controllable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAvailable(GameObject other)
    {
        recipient = other;
        Rider rider = recipient.GetComponent<Rider>();
        if (rider)
        {
            rider.availableRide = this;
        }
        if (prompt)
        {
            prompt.gameObject.SetActive(true);
        }
    }

    public void OnUnavailable(GameObject other)
    {
        Rider rider = recipient.GetComponent<Rider>();
        if (rider)
        {
            rider.availableRide = null;
        }

        recipient = null;

        if (prompt)
        {
            prompt.gameObject.SetActive(false);
        }
    }

    public void OnMount()
    {
        if(controllable)
        {
            controllable.lockMovement = false;
        }

        if (prompt)
        {
            prompt.gameObject.SetActive(false);
        }

    }

    public void OnDismount()
    {
        if(controllable)
        {
            controllable.lockMovement = true;
        }
    }
}
