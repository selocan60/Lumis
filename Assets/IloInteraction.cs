using System.Collections; // Zamanlayıcı (Coroutine) kullanmak için bu kütüphaneyi ekledik
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class IloInteraction : MonoBehaviour
{
    public GameObject interactText;
    private bool isPlayerInRange = false;
    private Coroutine hideTextCoroutine; // Sayacı kontrol edebilmek için bir değişken oluşturduk

    void Start()
    {
        if (interactText != null)
        {
            interactText.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerInRange && Keyboard.current != null && Keyboard.current.gKey.wasPressedThisFrame)
        {
            GiveRoses();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;

            if (interactText != null)
            {
                interactText.SetActive(true); // Yazıyı göster

                // Eğer daha önceden başlamış bir geri sayım varsa onu durdur ki çakışmasın
                if (hideTextCoroutine != null)
                {
                    StopCoroutine(hideTextCoroutine);
                }

                // 2 saniyelik geri sayımı başlat
                hideTextCoroutine = StartCoroutine(HideTextAfterSeconds(2f));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;

            if (interactText != null)
            {
                interactText.SetActive(false); // Alandan çıkınca anında gizle
            }

            // Alandan çıkarsa geri sayımı iptal et
            if (hideTextCoroutine != null)
            {
                StopCoroutine(hideTextCoroutine);
            }
        }
    }

    // SADECE BU KISIM GÜNCELLENDİ
    private void GiveRoses()
    {
        // GameManager'a kazanma şartını soruyoruz
        if (GameManager.Instance != null)
        {
            bool hasWon = GameManager.Instance.CheckWinCondition();

            if (hasWon)
            {
                Debug.Log("Güller ILO'ya başarıyla teslim edildi ve oyun kazanıldı!");
                if (interactText != null) interactText.SetActive(false);
                this.enabled = false;
            }
            else
            {
                Debug.Log("Henüz yeterli gülün yok!");
            }
        }
    }

    // Zamanlayıcı Metodumuz
    private IEnumerator HideTextAfterSeconds(float delay)
    {
        // Burada belirtilen süre (2 saniye) kadar hiçbir şey yapmadan bekler
        yield return new WaitForSeconds(delay);

        // Süre dolduğunda oyuncu hala alandaysa bile yazıyı kapatır
        if (interactText != null && isPlayerInRange)
        {
            interactText.SetActive(false);
        }
    }
}