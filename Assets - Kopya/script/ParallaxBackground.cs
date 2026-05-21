using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f; // Arka planın kayma hızı
    private SpriteRenderer spriteRenderer;
    private Material mat;
    private Vector2 offset;

    void Start()
    {
        // Nesne üzerindeki Sprite Renderer bileşenini alıyoruz
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Kodun doku offsetini değiştirebilmesi için materyali kopyalıyoruz
        mat = spriteRenderer.material;
    }

    void Update()
    {
        // Zamanla X eksenindeki offset değerini artırıyoruz
        offset.x += speed * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}