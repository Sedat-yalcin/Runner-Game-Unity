using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    public GameObject startingText;
    public void ReplayGame()
    {
        Debug.Log("Oyun yeniden başlasın");
       
       // Time.timeScale = 0;
       // Destroy(startingText);

        SceneManager.LoadScene("Level");

    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
