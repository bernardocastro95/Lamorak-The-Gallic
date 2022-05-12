using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField]
    private Button startButton, exitButton;

    public void loadGame()
    {
        startButton.onClick.AddListener(startGame);
        exitButton.onClick.AddListener(exitGame);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
