using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlLogic : MonoBehaviour
{
    public void LvlLogicUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LevelMgr.instance.UnloadCurrentScene();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LvlLogicUpdate();
    }
}
