using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Platform : MonoBehaviour
{
    public GameObject[] list;
    //GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerControl>()!=null)
        {
            foreach (GameObject go in list)
            {
                if (go != null)
                {
                    go.GetComponent<NavMeshAgent>().enabled = true;
                    go.GetComponent<AIMovement>().nav.SetDestination(other.transform.position);
                    go.GetComponent<AIMovement>().player = other.gameObject;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerControl>() != null)
        {
            foreach (GameObject go in list)
            {
                if (go != null)
                {
                    go.GetComponent<NavMeshAgent>().enabled = false;

                    go.GetComponent<AIMovement>().player = null;
                }
            }
        }
    }
}
