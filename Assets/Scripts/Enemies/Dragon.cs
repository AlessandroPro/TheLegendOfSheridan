using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public AudioClip roar;
    public AudioClip die;
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
        this.gameObject.GetComponent<AudioSource>().Stop();
        this.gameObject.GetComponent<AudioSource>().clip = roar;
        this.gameObject.GetComponent<AudioSource>().Play();
    }
    void beforeDeath()
    {
        this.gameObject.GetComponent<AudioSource>().clip = null;
        this.gameObject.GetComponent<AudioSource>().clip = die;
        this.gameObject.GetComponent<AudioSource>().Play();

    }
}
