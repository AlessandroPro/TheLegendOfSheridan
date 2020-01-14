using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        PlayerWeapon pw = other.GetComponent<PlayerWeapon>();
        if (pw)
        {
            if(pw.CanDestroyObjects)
            {
                Destroy(this.gameObject, 1);
            }
        }
    }
}
