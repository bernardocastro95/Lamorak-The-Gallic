﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2PauseMenu : MonoBehaviour
{
    [SerializeField]
    public Text middleText;
    [SerializeField]
    private Button gameButton;
    [SerializeField]
    private Button mainMenuButton;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gm == null)
        {
            Debug.LogError("No Game Manager");
        }
        gameButton.onClick.AddListener(resumeGame);
        mainMenuButton.onClick.AddListener(backtoMainMenu);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            gm.gameIsPaused();
            pauseMenu();

        }
    }
    void pauseMenu()
    {
        Time.timeScale = 0;
        middleText.text = "GAME PAUSED";
        gameButton.gameObject.SetActive(true);
        gameButton.GetComponentInChildren<Text>().text = "Resume";
        mainMenuButton.gameObject.SetActive(true);

    }
    void resumeGame()
    {
        Time.timeScale = 1;
        middleText.text = "";
        gameButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }
    void backtoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
