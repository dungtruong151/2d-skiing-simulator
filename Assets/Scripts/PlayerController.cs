using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 15f;
    [SerializeField] private float boostSpeed = 45f;
    [SerializeField] private float normalSpeed = 25f;
    [SerializeField] private Text scoreText; // Thêm tham chiếu đến UI Text
    private int score = 0; // Biến lưu điểm
    private bool canPlay;
    private Rigidbody2D _rb2D;
    private SurfaceEffector2D _surfaceEffector2D;

    private void Start()
    {
        canPlay = true;
        _rb2D = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

        // Cập nhật điểm số ban đầu
        UpdateScoreUI();
    }

    private void Update()
    {
        if (canPlay)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableInput()
    {
        canPlay = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _surfaceEffector2D.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb2D.AddTorque(torqueAmount * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb2D.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }

    // Hàm để thêm điểm
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    // Hàm cập nhật UI
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
