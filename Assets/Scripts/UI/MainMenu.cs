using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button selectedButon;
    // Start is called before the first frame update
    void Start()
    {
        selectedButon.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlay()
    {
        SceneManager.LoadScene("Overworld");
    }
    public void onExit()
    {
        Application.Quit();
    }
}
