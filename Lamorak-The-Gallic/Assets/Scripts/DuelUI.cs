using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelUI : MonoBehaviour
{
    [SerializeField]
    GameObject[] playerLifes;
    [SerializeField]
    GameObject[] enemyLifes;
    [SerializeField]
    Text middleText;
    [SerializeField]
    Button gameButton;
    [SerializeField]
    Button mainMenuButton;
    int lifes;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        lifes = 3;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gm == null)
        {
            Debug.LogError("No Game Manager");
        }
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
        
        lifes -= 1;

    }
    public void enemyLifeManager()
    {

        lifes -= 1;

    }

    public void pauseMenu()
    {
        Time.timeScale = 0;
        middleText.text = "                               GAME PAUSED";
        gameButton.gameObject.SetActive(true);
        gameButton.gameObject.GetComponentInChildren<Text>().text = "Resume";
        mainMenuButton.gameObject.SetActive(true);
        

    }
}
