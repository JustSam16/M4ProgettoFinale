using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHearts : MonoBehaviour
{
    public int maxHealth = 3;
    public List<Image> heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage()
    {
        if (currentHealth <= 0) return;

        currentHealth--;
        UpdateHearts();

        if (currentHealth <= 0)
        {
            FindObjectOfType<GameUIManager>().ShowGameOver();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            heartImages[i].sprite = i < currentHealth ? fullHeart : emptyHeart;
        }
    }
}

