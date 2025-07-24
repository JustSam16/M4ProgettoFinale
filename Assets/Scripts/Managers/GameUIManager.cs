using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    public Text coinText;
    public Text timerText;

    public Image victoryImage;
    public Image gameOverImage;
    public Button retryButton;
    public Button menuButton;

    public GameObject cheese;
    public int totalCoins = 3;

    public float gameTime = 120f;
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

        victoryImage.gameObject.SetActive(false);
        gameOverImage.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);

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
        victoryImage.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowGameOver()
    {
        if (gameEnded) return;

        gameEnded = true;
        gameOverImage.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void UpdateCoinUI()
    {
        coinText.text = currentCoins + " / " + totalCoins;
    }
}
