using System.Collections;
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
        middleText.text = "Press A, D or arrow keys to move. Press Space to jump. You need to run to the end before time runs out";
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            gm.gameIsPaused();
            pauseMenu();

        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            middleText.text = "";
        }
    }
    void pauseMenu()
    {
        Time.timeScale = 0;
        middleText.text = "GAME PAUSED";
        gameButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        gameButton.GetComponentInChildren<Text>().text = "Resume";
        mainMenuButton.GetComponentInChildren<Text>().text = "Main Menu";
        

    }
    void resumeGame()
    {
        gm.gameNotPaused();
        Time.timeScale = 1;
        middleText.text = "";
        gameButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }
    void backtoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void levelWon()
    {
        Time.timeScale = 0;
        middleText.text = "Well done";
    }

}
