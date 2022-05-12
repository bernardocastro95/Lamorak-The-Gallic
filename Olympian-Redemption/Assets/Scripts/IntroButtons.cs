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
    }

    public void level1()
    {
        SceneManager.LoadScene(2);
    }
    public void backMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
