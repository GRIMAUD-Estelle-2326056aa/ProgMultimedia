using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public int mushrooms = 0;
    public int keys = 0;
    public TextMeshProUGUI scoreText;
    public List<GameObject> objects = new List<GameObject>();

    public void AddObject(GameObject obj)
    {
        objects.Add(obj);
        Debug.Log("Objet ajouté au joueur : " + obj.name);
    }

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

    public void AddKeys(int amount)
    {
        keys += amount;
        Debug.Log($"Keys: {keys}");
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score : " + mushrooms;
    }
}
