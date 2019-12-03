using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject player;
    public Button selectedButton;
    // Start is called before the first frame update
    void Start()
    {
        selectedButton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onResume()
    {
        Time.timeScale = 1f;
        player.GetComponent<PlayerControl>().isPaused = false;
        this.gameObject.SetActive(false);
    }
    public void onExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
