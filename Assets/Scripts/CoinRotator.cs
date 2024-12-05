using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; 
    [SerializeField] private float bounceAmplitude = 0.3f; 
    [SerializeField] private float bounceFrequency = 2f;   

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position; 
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        float newY = startPosition.y + Mathf.Sin(Time.time * bounceFrequency) * bounceAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
