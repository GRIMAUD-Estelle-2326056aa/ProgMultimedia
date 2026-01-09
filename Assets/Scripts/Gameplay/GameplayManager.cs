using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;


    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameplayUIManager uiManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    public void GameOver()
    {
        Debug.Log("GAME OVER");

        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement NON RÉFÉRENCÉ !");
            return;
        }

        // Désactivation du script de mouvement
        if (playerMovement != null)
            playerMovement.enabled = false;

        // Affichage UI
        uiManager.ShowGameOver();

        // Optionnel : pause globale
        Time.timeScale = 0f;
    }

    public void Victory()
    {
        Debug.Log("Victory");

        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement NON RÉFÉRENCÉ !");
            return;
        }

        // Désactivation du script de mouvement
        if (playerMovement != null)
            playerMovement.enabled = false;

        // Affichage UI
        uiManager.ShowVictory();

        // Optionnel : pause globale
        Time.timeScale = 0f;
    }
}
