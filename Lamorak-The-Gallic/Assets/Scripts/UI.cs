using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text lifeText;
    [SerializeField]
    public Text middleText;
    [SerializeField]
    private Button gameButton;
    [SerializeField]
    private Button mainMenuButton;
    public int lifes;
    private GameManager gm;
    [SerializeField]
    private Arrow arrow;
    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = 3 + " Shots";
        lifes = 3;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(gm == null)
        {
            Debug.LogError("No Game Manager");
        }
        gameButton.onClick.AddListener(resumeGame);
        gameButton.onClick.AddListener(restartGame);
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

    public void lifeUiManager()
    {
        lifes -= 1;
        lifeText.text = lifes.ToString() + " Shots";

        if(lifes == 0)
        {
            gm.gameIsOver();
            Time.timeScale = 0;
            middleText.text = "GAME OVER";
            gameButton.gameObject.SetActive(true);
            gameButton.GetComponentInChildren<Text>().text = "Restart";
            mainMenuButton.gameObject.SetActive(true);

        }
    }
    void pauseMenu()
    {   Time.timeScale = 0;
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
        lifeText.text = lifes.ToString() + " Shots";
    }
    void restartGame()
    {
        SceneManager.LoadScene(2);
        middleText.text = "";
        gameButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        lifeText.text = 3 + " Shots";
        lifes = 3;
    }
    void backtoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
