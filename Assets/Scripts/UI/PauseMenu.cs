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
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnEnable()
    {
        selectedButton.Select();
    }
    public void onResume()
    {
        Time.timeScale = 1f;
        player.GetComponent<PlayerControl>().isPaused = false;
        this.gameObject.SetActive(false);
    }
    public void onRestart()
    {

    }
    public void onExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
