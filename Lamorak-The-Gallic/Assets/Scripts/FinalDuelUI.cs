using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalDuelUI : MonoBehaviour
{
    [SerializeField]
    Text middleText;
    [SerializeField]
    Button gameButton;
    [SerializeField]
    Button mainMenuButton;
    [SerializeField]
    Button restartButton;
    int playerLifes, enemyLifes;
    private GameManager gm;
    [SerializeField]
    Text PlayerLifesCounter;
    [SerializeField]
    Text EnemyLifesCounter;
    // Start is called before the first frame update
    void Start()
    {
        playerLifes = 3;
        enemyLifes = 3;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gm == null)
        {
            Debug.LogError("No Game Manager");
        }
        gameButton.onClick.AddListener(resumeGame);
        mainMenuButton.onClick.AddListener(backtoMainMenu);
        restartButton.onClick.AddListener(restartGame);
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
        playerLifes -= 1;
        PlayerLifesCounter.text = playerLifes.ToString();

        if (playerLifes == 0)
        {

            Time.timeScale = 0;
            gm.gameIsOver();
            middleText.text = "                 GAME OVER";
            restartButton.gameObject.SetActive(true);
            restartButton.GetComponentInChildren<Text>().text = "Restart";
            mainMenuButton.gameObject.SetActive(true);

        }

    }
    public void enemyLifeManager()
    {
        enemyLifes -= 1;
        EnemyLifesCounter.text = enemyLifes.ToString();
        if (enemyLifes == 0)
        {
            Time.timeScale = 0;
            gm.gameIsPaused();
            middleText.text = "                WELL DONE";
            SceneManager.LoadScene(9);
        }

    }

    void pauseMenu()
    {
        Time.timeScale = 0;
        middleText.text = "                 GAME PAUSED";
        gameButton.gameObject.SetActive(true);
        gameButton.gameObject.GetComponentInChildren<Text>().text = "Resume";
        mainMenuButton.gameObject.SetActive(true);


    }
    void restartGame()
    {
        SceneManager.LoadScene(8);
        middleText.text = "";
        restartButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }
    void resumeGame()
    {
        gm.gameNotPaused();
        Time.timeScale = 1;
        middleText.text = "";
        gameButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }
    public void backtoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
