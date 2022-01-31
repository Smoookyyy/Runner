using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject LoseWindow;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void LoseGame()
    {
        LoseWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        LoseWindow.SetActive(false);
        Time.timeScale = 1;
    }
}
