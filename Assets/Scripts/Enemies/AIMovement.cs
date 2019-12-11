using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public GameObject Hand;
    public GameObject Weapon;
    public GameObject player;
    public NavMeshAgent nav;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            if (nav.enabled == true)
            {
                nav.SetDestination(player.transform.position);
                anim.SetBool("player", true);
                if (Vector3.Distance(this.transform.position, player.transform.position) <= nav.stoppingDistance)
                {
                    anim.SetBool("attack", true);
                }
                else
                {
                    anim.SetBool("attack", false);
                }
            }
        }
        if (player == null)
        {
            anim.SetBool("player", false);
        }

        if (this.gameObject.GetComponent<Enemy>().health <= 0.0f)
        {
            anim.SetTrigger("die");
        }


    }
    void pickUp()
    {
        Weapon.transform.position = Hand.transform.position;
        Weapon.transform.rotation = Hand.transform.rotation;
        Weapon.transform.SetParent(Hand.transform);

    }
    void walk()
    {
        nav.enabled = true;
    }
    void Die()
    {
        Destroy(this.gameObject);
    }
}
    

