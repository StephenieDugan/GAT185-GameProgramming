using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] PhysicsCharacterController characterController;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] voidEvent gameStartEvent = default;

    private int score = 0;
    public int Score { 
        get { return score; } 

        set { score = value; 
            scoreText.text = "Score: " + score; 
            scoreEvent.RaiseEvent(score); } }

    private void Start()
    {
        health.value = 50.0f;
    }
    public void AddPoints(int points)
    {
        score += points;
    }

    private void OnEnable()
    {
        gameStartEvent.Subscribe(onStartGame);
    }
   
    private void onStartGame()
    {
        characterController.enabled = true;
    }


}
