using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 15f;
    [SerializeField] private float boostSpeed = 25f;
    [SerializeField] private float baseSpeed = 25f;
    [SerializeField] private float speedIncrement = 10f;
    private float currentSpeed;
    private bool canPlay;
    private Rigidbody2D _rb2D;
    private SurfaceEffector2D _surfaceEffector2D;

    private void Start()
    {
        canPlay = true;
        _rb2D = GetComponent<Rigidbody2D>();
        int level = PlayerPrefs.GetInt("SelectedLevel", 1); 
        currentSpeed = baseSpeed + (level - 1) * speedIncrement; 
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        _surfaceEffector2D.speed = currentSpeed;
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
            _surfaceEffector2D.speed = currentSpeed + boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _surfaceEffector2D.speed = currentSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb2D.AddTorque(-torqueAmount);
        }
    }
}
