using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // <-- Sahne geçişleri için bu kütüphaneyi ekledik

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Diğer kodlardan rahatça ulaşabilmek için (Singleton)

    [Header("UI Elemanları")]
    public TextMeshProUGUI roseText;
    public TextMeshProUGUI timerText;
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("Oyun Ayarları")]
    public int totalRosesInLevel = 10; // Bölümdeki toplam gül sayısı (10 olarak güncellendi)
    public float timeLimit = 60f; // Saniye cinsinden süre sınırı

    private int currentRoses = 0;
    private float timeRemaining;
    private bool isGameOver = false;

    void Awake()
    {
        // Singleton yapısı kurulumu
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateRoseUI();
    }

    void Update()
    {
        if (isGameOver) return;

        // Zamanlayıcıyı geriye doğru saydırıyoruz
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            timeRemaining = 0;
            UpdateTimerUI();
            LoseGame(); // Süre bittiğinde kaybetme senaryosu
        }
    }

    // Gül toplandığında çağrılacak metod
    public void CollectRose()
    {
        if (isGameOver) return;

        currentRoses++;
        UpdateRoseUI();
    }

    // ILO'ya güller verilmek istendiğinde kontrol edilecek metod
    public bool CheckWinCondition()
    {
        if (currentRoses >= totalRosesInLevel)
        {
            WinGame();
            return true;
        }
        return false;
    }

    void UpdateRoseUI()
    {
        if (roseText != null)
            roseText.text = "ROSE: " + currentRoses + "/" + totalRosesInLevel;
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
            // Sadece sayıyı yazdırır, başındaki Türkçe kelime kaldırıldı
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    public void WinGame()
    {
        isGameOver = true;
        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f; // Oyunu dondurur
    }

    public void LoseGame()
    {
        isGameOver = true;
        if (losePanel != null) losePanel.SetActive(true);
        Time.timeScale = 0f; // Oyunu dondurur
    }

    // --- YENİ EKLENEN MENÜYE DÖNÜŞ FONKSİYONU ---
    public void AnaMenuyeDon()
    {
        Time.timeScale = 1f; // Oyun donmuş durumdaydı, zaman akışını normale döndürüyoruz
        SceneManager.LoadScene("MainMenu"); // Projendeki MainMenu sahnesini yükler
    }
}