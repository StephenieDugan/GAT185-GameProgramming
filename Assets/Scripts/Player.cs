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
    [SerializeField] voidEvent playerDeadEvent = default;

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
        gameStartEvent.Subscribe(onStartGame);
    }
   
    private void onStartGame()
    {
        characterController.enabled = true;
    }
    public void OnRespawn(GameObject respawn)
    {
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        characterController.Reset();

    }


}
