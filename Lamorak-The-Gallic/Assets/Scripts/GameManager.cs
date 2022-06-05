using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public bool paused = false;
    public bool gameRunning = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameIsOver()
    {
        isGameOver = true;
        gameRunning = false;
    }
    public void gameIsPaused()
    {
        paused = true;
        gameRunning = false;
    }
    public void gameNotPaused()
    {
        paused = false;
        gameRunning = true;
    }
}
