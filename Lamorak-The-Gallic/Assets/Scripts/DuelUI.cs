using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DuelUI : MonoBehaviour
{
    [SerializeField]
    Text middleText;
    [SerializeField]
    Button gameButton;
    [SerializeField]
    Button mainMenuButton;
    int playerLifes, enemyLifes;
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
        gameButton.onClick.AddListener(restartGame);
        mainMenuButton.onClick.AddListener(backtoMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            gm.gameIsPaused();
            pauseMenu();

        }
    }

    public void playerLifeManager()
    {
        playerLifes = 3;
        playerLifes -= 1;
        if(playerLifes == 0)
        {

        }

    }
    public void enemyLifeManager()
    {
        enemyLifes = 3;
        enemyLifes -= 1;
        if(enemyLifes < 0)
        {

        }

    }

    public void pauseMenu()
    {
        Time.timeScale = 0;
        middleText.text = "                 GAME PAUSED";
        gameButton.gameObject.SetActive(true);
        gameButton.gameObject.GetComponentInChildren<Text>().text = "Resume";
        mainMenuButton.gameObject.SetActive(true);
        

    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        middleText.text = "";
        gameButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }
    public void restartGame()
    {
        Time.timeScale = 1;
        middleText.text = "";
        gameButton.gameObject.SetActive(false);
    }
    public void backtoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
