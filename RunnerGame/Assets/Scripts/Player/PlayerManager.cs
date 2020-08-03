using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public   GameObject startingText;
    public static int numberOfCoins;
    public Text coinsText;
   

    void Start()
    {
        Debug.Log("Oyun Başladı");
        gameOver = false;
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Debug.Log("Oyun Bitti");
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            numberOfCoins = 0;


        }
        else
        {
           // startingText.SetActive(false);
        }

       
        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);

        }

        coinsText.text = "Coins: " + numberOfCoins;
        
    }
}
