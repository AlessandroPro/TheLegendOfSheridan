using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button selectButton;
    // Start is called before the first frame update
    void Start()
    {
        selectButton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void onExit()
    {
        Application.Quit();
    }
}
