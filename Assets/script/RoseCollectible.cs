using UnityEngine;

public class RoseCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Çarpan obje tilki mi (Player) kontrol et
        if (collision.CompareTag("Player"))
        {
            // GameManager'ı bul ve sayacı 1 artır komutunu yolla
            if (GameManager.Instance != null)
            {
                GameManager.Instance.CollectRose();
            }

            // Sayacı artırdıktan sonra gülü sahneden yok et
            Destroy(gameObject);
        }
    }
}