using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sword : MonoBehaviour
{
     Animator anim;
    NavMeshAgent navigator;
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
        Debug.Log(other.gameObject.name);
        anim = other.gameObject.GetComponent<Animator>();
        navigator = other.gameObject.GetComponent<NavMeshAgent>();
        navigator.enabled=false;
        anim.SetTrigger("weapon");
       // this.gameObject.GetComponent<BoxCollider>().enabled= false;
        other.GetComponent<AIMovement>().Weapon = this.gameObject;
    }
}
