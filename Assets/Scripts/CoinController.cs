using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private ParticleSystem collectEffect;
    [SerializeField] private AudioClip collectSound;
    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true;

            // Gọi PlayerController để cộng điểm
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.AddScore(1);
            }

            // Hiển thị hiệu ứng
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            // Phát âm thanh
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            }

            // Hủy đối tượng đồng xu
            Destroy(gameObject);
        }
    }
}
