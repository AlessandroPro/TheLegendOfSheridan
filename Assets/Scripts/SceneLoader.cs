using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool toGlobal = false;
    public string level; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!toGlobal)
            {
                LevelMgr.instance.LoadGameplayScene(level);
            }
            else
            {
                LevelMgr.instance.UnloadCurrentScene();
            }
        }
    }
}
