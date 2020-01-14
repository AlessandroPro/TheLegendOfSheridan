using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireBall : MonoBehaviour
{
    public GameObject DragonMouth;
    public GameObject player;
    private bool release = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Release());
    }

    // Update is called once per frame
    void Update()
    {
        if(!release)
        {
            transform.position = DragonMouth.transform.position;
        }

        if(!player)
        {
            Destroy(this.gameObject, 1.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerControl>()!=null)
        {
            Destroy(this.gameObject, 1.0f);
        }
        else
        {
            Destroy(this.gameObject, 4.0f);

        }
    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(1);
        release = true;
        if(player != null)
        {
            GetComponent<Rigidbody>().AddForce(((player.transform.position + Vector3.up) - transform.position) * 100);
        }
    }
}
