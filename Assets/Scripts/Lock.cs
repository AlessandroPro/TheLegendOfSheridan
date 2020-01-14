using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Gate gate;
    public GameObject particles;

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
        if(other.GetComponent<Key>())
        {
            StartCoroutine(Unlock());
        }
    }


    IEnumerator Unlock()
    {
        var particleSystems = particles.gameObject.GetComponentsInChildren<ParticleSystem>();

        foreach (var ps in particleSystems)
        {
            ps.Play();
        }

        yield return new WaitForSeconds(2);
        GetComponent<MeshRenderer>().enabled = false;

        particleSystems = particles.gameObject.GetComponentsInChildren<ParticleSystem>();

        foreach (var ps in particleSystems)
        {
            ps.Stop();
        }
        yield return new WaitForSeconds(1);
        gate.locked = false;
        GetComponent<BoxCollider>().enabled = false;
        Destroy(this);
    }
}
