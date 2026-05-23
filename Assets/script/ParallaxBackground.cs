using UnityEngine;

public class ParallaxBg : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    [Tooltip("0 = Arka plan kamerayla tamamen aynı hızda hareket eder (sabit kalır).\n1 = Arka plan hiç hareket etmez.")]
    [Range(0f, 1f)]
    public float parallaxEffectMultiplier = 0.5f;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        // Kameranın ne kadar hareket ettiğini bul
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // Arka planı, kameranın hareketinin belli bir oranı kadar hareket ettir
        transform.position += new Vector3(deltaMovement.x * (1 - parallaxEffectMultiplier), 0, 0);

        lastCameraPosition = cameraTransform.position;
    }
}