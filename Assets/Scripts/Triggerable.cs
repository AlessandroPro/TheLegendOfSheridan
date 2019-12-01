using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class RecipientEvent : UnityEvent<GameObject> { }

public class Triggerable : MonoBehaviour
{
    public List<RecipientEvent> OnCloseEnough;
    public List<RecipientEvent> OnTooFar;

    public void OnTriggerEnter(Collider col)
    {
        // if we collide with an object that is allowed to interact with us
        // then dispatch the 'close enough' events

        if (col.gameObject.GetComponent<PlayerControl>())
        {
            foreach (RecipientEvent e in OnCloseEnough)
            {
                if (e != null)
                    e.Invoke((GameObject)col.gameObject);
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<PlayerControl>())
        {
            foreach (RecipientEvent e in OnTooFar)
            {
                if (e != null)
                    e.Invoke((GameObject)col.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void TriggerableUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TriggerableUpdate();
    }
}
