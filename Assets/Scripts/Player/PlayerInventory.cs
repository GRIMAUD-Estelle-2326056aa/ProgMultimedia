using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public int mushrooms = 0;
    public int keys = 0;
    public TextMeshProUGUI scoreText;
    public List<GameObject> objects = new List<GameObject>();

    void Start()
    {
        UpdateScoreUI();
    }
    // Récupération des objets
    public void AddObject(GameObject obj)
    {
        objects.Add(obj);
        Debug.Log($"Ajout de l'objet {obj.name}");
    }
    // Récupération de champignons
    public void AddMushrooms(GameObject mushroom)
    {
        objects.Add(mushroom);
        mushrooms += 1;
        Debug.Log($"mushrooms: {mushrooms}");
        UpdateScoreUI();
    }
    // Récupération de clé
    public void AddKeys(GameObject key)
    {
        objects.Add(key);
        keys += 1;
        Debug.Log($"Keys: {keys}");
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score : " + mushrooms;
    }
}
