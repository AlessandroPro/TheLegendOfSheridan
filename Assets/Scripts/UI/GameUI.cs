using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameObject player;
    public Slider healthBar;
    int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = (int) player.GetComponent<PlayerControl>().health;
        healthBar.value = health;
    }
}
