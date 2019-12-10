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
        leftDoor.transform.rotation = Quaternion.Slerp(leftDoor.transform.rotation, Quaternion.AngleAxis(180+openAngle, Vector3.up), Time.deltaTime * 2);
        rightDoor.transform.rotation = Quaternion.Slerp(rightDoor.transform.rotation, Quaternion.AngleAxis(-openAngle, Vector3.up), Time.deltaTime * 2);
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
