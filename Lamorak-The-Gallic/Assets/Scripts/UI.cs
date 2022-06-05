using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text lifeText;
    [SerializeField]
    private Text middleText;
    [SerializeField]
    private Button gameButton;
    [SerializeField]
    private Button mainMenuButton;
    public int lifes;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = "X" + 3;
        lifes = 3;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(gm == null)
        {
            Debug.LogError("No Game Manager");
        }
        gameButton.enabled = false;
    }

    public void lifeUiManager()
    {
        lifes -= 1;
        lifeText.text = "X" + lifes.ToString();

        if(lifes == 0)
        {
            gm.gameIsOver();
            Time.timeScale = 0;
            middleText.text = "GAME OVER";

        }
    }
}
