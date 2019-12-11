using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool locked = true;
    public GameObject opener;
    float openAngle = 0;

    public GameObject leftDoor;
    public GameObject rightDoor;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Triangle Button") && !locked && opener)
        {
            if(Vector3.Angle(opener.transform.forward, transform.forward) < 30)
            {
                StartCoroutine(Open());
            }
        }
        float angle = Vector3.SignedAngle(Vector3.forward, transform.forward, Vector3.up);
        leftDoor.transform.rotation = Quaternion.Slerp(leftDoor.transform.rotation, Quaternion.AngleAxis(angle + 180+openAngle, Vector3.up), Time.deltaTime * 2);
        rightDoor.transform.rotation = Quaternion.Slerp(rightDoor.transform.rotation, Quaternion.AngleAxis(angle - openAngle, Vector3.up), Time.deltaTime * 2);
    }

    IEnumerator Open()
    {
        opener.gameObject.GetComponent<Animator>().SetTrigger("Interaction");
        yield return new WaitForSeconds(1);
        openAngle = 120;
        
    }

        public void OnAvailable(GameObject other)
    {
        opener = other;
    }

    public void OnUnavailable(GameObject other)
    {
        opener = null;
    }
}
