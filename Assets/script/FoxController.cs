using UnityEngine;
using UnityEngine.InputSystem;

public class FoxController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Eşya Toplama Sistemi")]
    public int collectedRoses = 0;

    [Header("UI Paneli (Bölüm Sonu)")]
    public GameObject winPanel; // Ekranda açılacak tebrikler paneli

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private float moveInput;
    private bool isGrounded;
    private bool isNearNPC = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Oyun başında eğer panel açıksa otomatik olarak gizle
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    void Update()
    {
        moveInput = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                moveInput = 1f;
            else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                moveInput = -1f;

            isGrounded = Mathf.Abs(rb.linearVelocity.y) < 0.05f;
            if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }

            // --- GÜNCELLENEN KISIM: G TUŞUNA BASILDIĞINDA ---
            if (Keyboard.current.gKey.wasPressedThisFrame && isNearNPC)
            {
                // ARTIK KONTROLÜ TAMAMEN GAMEMANAGER'A DEVREDİYORUZ
                if (GameManager.Instance != null)
                {
                    // GameManager içindeki CheckWinCondition metodunu çağırıyoruz.
                    // O metod eğer 10 gül toplandıysa true dönecek ve oyunu durduracak.
                    // Eğer 10 gül toplanmadıysa false dönecek ve oyun AKMAYA DEVAM EDECEK!
                    GameManager.Instance.CheckWinCondition();
                }
            }
        }

        // --- YÖN DÖNDÜRME VE ANİMASYON MANTIĞI ---

        // 1. Karakterin yönünü çevirme (Zaten senin kodunda çok güzel kurulmuştu)
        if (moveInput != 0)
        {
            spriteRenderer.flipX = (moveInput < 0);
        }

        // 2. Animatöre hızı iletme (Önceki isRunning boolean'ı yerine Speed Float'ını kullanıyoruz)
        // Mathf.Abs, moveInput -1 (sola) olsa bile animatöre 1 olarak gönderir ki koşu animasyonu tetiklensin.
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rose"))
        {
            Destroy(collision.gameObject);
            collectedRoses++;
        }

        if (collision.CompareTag("NPC"))
        {
            isNearNPC = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            isNearNPC = false;
        }
    }
}