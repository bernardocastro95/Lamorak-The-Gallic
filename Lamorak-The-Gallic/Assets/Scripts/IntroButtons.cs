using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroButtons : MonoBehaviour
{
    [SerializeField]
    private Button beginButton, backButton;

    public void loadGame()
    {
        beginButton.onClick.AddListener(level1);
        backButton.onClick.AddListener(backMainMenu);
        beginButton.onClick.AddListener(level2);
        beginButton.onClick.AddListener(level3);
    }

    public void level1()
    {
        SceneManager.LoadScene(2);
    }
    public void backMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void level2()
    {
        SceneManager.LoadScene(4);
    }
    public void level3()
    {
        SceneManager.LoadScene(6);
    }
}
