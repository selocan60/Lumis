using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Elementleri")]
    public GameObject pauseMenuPanel; // Menü panelimizi buraya bağlayacağız

    void Update()
    {
        // Klavyeden ESC tuşuna basıldığında menüyü açıp kapatma (İsteğe bağlı)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuPanel.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // --- BUTONLARA BAĞLAYACAĞIMIZ FONKSİYONLAR ---

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true); // Paneli görünür yap
        Time.timeScale = 0f;            // Zamanı durdur (oyun donar)
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false); // Paneli gizle
        Time.timeScale = 1f;             // Zamanı normale döndür
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f; // Ana menüye dönerken zamanı düzeltmeyi unutma!

        // "MainMenu" yazan yere Ana Menü sahnenin tam adını yazmalısın.
        SceneManager.LoadScene("MainMenu");
    }
}