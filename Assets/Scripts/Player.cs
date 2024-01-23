using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] FloatVariable health;
    [SerializeField] PhysicsCharacterController characterController;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] voidEvent gameStartEvent = default;
    [SerializeField] voidEvent gameWinEvent = default;
    [SerializeField] voidEvent playerDeadEvent = default;

    private int score = 0;
    public int lives = 0;
    public int Score { 
        get { return score; } 

        set { score = value; 
            scoreText.text = "Score: " + score; 
            scoreEvent.RaiseEvent(score); 
        } 
    }

    public int Lives
    {
        get { return lives; }
        set { livesUI.text = $"lives: {lives}"; }

    }

    private void Start()
    {
        health.value = 50.0f;
    }
    public void AddPoints(int points)
    {
        Score += points;
        if(Score >= 10)
        {
            gameWinEvent.RaiseEvent();
        }
    }
    public void Damage(float damage)
    {
        health.value -= damage;
        if(health.value <=0)
        {
            playerDeadEvent.RaiseEvent();
            
        }
    }

    private void OnEnable()
    {
        gameStartEvent.Subscribe(OnStartGame);
    }
   
    private void OnStartGame()
    {
        characterController.enabled = true;
        lives = 3;
        Score = 0;
    }
   
    public void OnRespawn(GameObject respawn)
    {
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        lives -= 1;
        characterController.Reset();

    }
   


}
