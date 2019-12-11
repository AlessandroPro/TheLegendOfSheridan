using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public AudioClip roar;
    public AudioClip die;
    public GameObject fireballPrefab;
    public GameObject mouth;
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
        var fireball = Instantiate(fireballPrefab, mouth.transform.position, mouth.transform.rotation);
        fireball.GetComponent<FireBall>().DragonMouth = mouth;
        fireball.GetComponent<FireBall>().player = GetComponent<AIMovement>().player;
        this.gameObject.GetComponent<AudioSource>().Stop();
        this.gameObject.GetComponent<AudioSource>().clip = roar;
        this.gameObject.GetComponent<AudioSource>().Play();
    }
    void beforeDeath()
    {
        GetComponent<AIMovement>().player = null;
        this.gameObject.GetComponent<AudioSource>().clip = null;
        this.gameObject.GetComponent<AudioSource>().clip = die;
        this.gameObject.GetComponent<AudioSource>().Play();

    }


}
