using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timeOn = false;
    public Text timeTxt;
    [SerializeField]
    Button restart, menu;
    [SerializeField]
    Text middleText;
    [SerializeField]
    GameManager gm;
    AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        timeOn = true;
        restart.onClick.AddListener(restartGame);
        menu.onClick.AddListener(mainMenu);
        aSource = GetComponent<AudioSource>();
        aSource.Stop();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerUpdate(timeLeft);

                if(timeLeft >= 5.00f)
                {
                    aSource.Play();
                }
            } 
            else
            {
                gm.gameIsOver();
                gameOverScreen();
                aSource.Stop();
            }
        }
    }

    void timerUpdate(float current)
    {
        current += 1;

        float mins = Mathf.FloorToInt(current / 60);
        float secs = Mathf.FloorToInt(current % 60);

        timeTxt.text = string.Format("{0:00} : {1:00}", mins, secs);
    }

    void gameOverScreen()
    {
        Time.timeScale = 0;
        middleText.text = "GAME OVER";
        restart.gameObject.SetActive(true);
        restart.GetComponentInChildren<Text>().text = "Restart";
        menu.gameObject.SetActive(true);
        menu.GetComponentInChildren<Text>().text = "Main Menu";

    }
    void restartGame()
    {
        SceneManager.LoadScene(4);
        middleText.text = "";
        restart.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
    }
    void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
