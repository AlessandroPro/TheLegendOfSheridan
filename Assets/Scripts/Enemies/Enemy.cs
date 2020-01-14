using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100.0f;

    public SkinnedMeshRenderer meshRend;
    public Material[] DamageMats;

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
        if(other.gameObject.GetComponent<PlayerWeapon>()!=null)
        {
            health -= other.gameObject.GetComponent<PlayerWeapon>().damage;
            StartCoroutine(ShowDamage());
        }
    }

    private IEnumerator ShowDamage()
    {
        var DefaultMats = meshRend.materials;
        meshRend.materials = DamageMats;
        yield return new WaitForSeconds(0.5f);
        meshRend.materials = DefaultMats;
    }
}
