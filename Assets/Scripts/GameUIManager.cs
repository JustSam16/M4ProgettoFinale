using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    public Text coinText;
    public Text timerText;

    public GameObject victoryPanel;
    public GameObject gameOverPanel;
    public Image victoryImage;
    public Image gameOverImage;

    public GameObject cheese; 
    public int totalCoins = 3;

    public float gameTime = 60f; 
    private float currentTime;

    private int currentCoins = 0;
    private bool gameEnded = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateCoinUI();
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        if (cheese != null)
            cheese.SetActive(false);

        currentTime = gameTime;
    }

    void Update()
    {
        if (gameEnded) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f); 

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        UpdateTimerUI(formattedTime);

        if (currentTime <= 0f)
        {
            ShowGameOver();
        }
    }

    public void CollectCoin()
    {
        if (gameEnded) return;

        currentCoins++;
        UpdateCoinUI();

        if (currentCoins >= totalCoins && cheese != null)
        {
            cheese.SetActive(true);
        }
    }

    public void UpdateTimerUI(string timeText)
    {
        timerText.text = timeText;
    }

    public void ShowVictory()
    {
        if (gameEnded) return;

        gameEnded = true;
        victoryPanel.SetActive(true);
        victoryImage.enabled = true;
    }

    public void ShowGameOver()
    {
        if (gameEnded) return;

        gameEnded = true;
        gameOverPanel.SetActive(true);
        gameOverImage.enabled = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void UpdateCoinUI()
    {
        coinText.text = currentCoins + " / " + totalCoins;
    }
}
