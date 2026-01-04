using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int mushrooms = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddMushrooms(int amount)
    {
        mushrooms += amount;
        Debug.Log($"Mushrooms: {mushrooms}");
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score : " + mushrooms;
    }
}
