using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireBall : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject DragonMouth;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void fireball()
    {
       fireBall= Instantiate(fireBall, DragonMouth.transform.position, DragonMouth.transform.rotation);
        fireBall.GetComponent<Rigidbody>().AddForce((this.gameObject.GetComponent<AIMovement>().player.transform.position - fireBall.transform.position)*100);
        
    }
}
