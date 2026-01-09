using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIManager : MonoBehaviour
{
    // public GameObject startPanel;
    public GameObject victoryPanel;
    public GameObject gameOverPanel;

    void Start()
    {
        // État initial : écran de démarrage
        // Time.timeScale = 0f;

        // startPanel.SetActive(true);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Bouton "Start"
    // public void StartGame()
    // {
    //     startPanel.SetActive(false);
    //     Time.timeScale = 1f;

    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;
    // }

    public void ShowVictory()
    {
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowGameOver()
    {
         Debug.Log("GAME OVER");

        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
                Debug.Log("active" + gameOverPanel.name);


        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
