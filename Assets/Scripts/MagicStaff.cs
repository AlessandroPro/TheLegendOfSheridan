using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStaff : MonoBehaviour
{
    public GameObject magicPrefab;
    private GameObject magic;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void castMagic(GameObject entity)
    {
        //if(magic != null)
        //{
        //    Destroy(magic);
        //}
        //magic = 
        Instantiate(magicPrefab, entity.transform.position, entity.transform.rotation);
    }
}
