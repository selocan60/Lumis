using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Kameranın gidebileceği en sol ve en sağ sınırlar
    public float minX;
    public float maxX;

    void Start()
    {
        if (target != null)
        {
            // Başlangıçta da kamerayı sınırlar içinde tut
            float clampedX = Mathf.Clamp(target.position.x + offset.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Karakterin gitmek istediği X pozisyonu
            float targetX = target.position.x + offset.x;

            // Mathf.Clamp ile kameranın X pozisyonunu minX ve maxX arasına sıkıştırıyoruz
            float clampedX = Mathf.Clamp(targetX, minX, maxX);

            Vector3 desiredPosition = new Vector3(clampedX, transform.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}