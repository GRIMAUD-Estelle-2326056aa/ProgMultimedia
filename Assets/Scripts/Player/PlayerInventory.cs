using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Events;


public class PlayerInventory : MonoBehaviour
{
    public UnityEvent OnVictory;
    public int mushrooms = 0;
    public int keys = 0;
    public AnimatableTrophy trophy;
    public TextMeshProUGUI scoreText;
    public List<GameObject> objects = new List<GameObject>();
    void Start()
    {
        UpdateScoreUI();

        if (trophy != null)
        {
            trophy.OnAnimationEnded += HandleVictory;
        }
    }

    private void HandleVictory()
    {
        OnVictory?.Invoke();
    }
    // Récupération des objets
    public void AddObject(GameObject obj)
    {
        objects.Add(obj);
        if (obj == trophy.gameObject)
        {
            trophy.Animate();

        }
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
        {
                scoreText.text = "x " + mushrooms;

        }
    }

    public bool HasObject(GameObject obj)
    {
        return objects.Contains(obj);
    }

    public bool HasKey()
    {
        return keys == 1;
    }



}
