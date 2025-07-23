using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("ObstacleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
