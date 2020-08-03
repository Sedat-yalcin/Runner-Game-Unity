using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
   public void ReplayGame()
    {
        Debug.Log("Oyun yeniden başlasın");
        
        SceneManager.LoadScene("Level");

        

    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
