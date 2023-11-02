using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalSceneButtons : MonoBehaviour
{
    [SerializeField]
    private Button exitButton, mainMenuButton;
    

    public void loadScene()
    {
        exitButton.onClick.AddListener(endGame);
        mainMenuButton.onClick.AddListener(backToMainMenu);
    }

    public void endGame()
    {
        Application.Quit();
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
