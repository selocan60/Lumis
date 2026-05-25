using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    public GameObject helpPanel; // Paneli buraya bağlayacağız

    public void OyunaBasla()
    {
        // Ekran görüntündeki oyun sahnesinin adı
        SceneManager.LoadScene("GameScene");
    }

    public void PaneliAc()
    {
        helpPanel.SetActive(true);
    }

    public void PaneliKapat()
    {
        helpPanel.SetActive(false);
    }
}