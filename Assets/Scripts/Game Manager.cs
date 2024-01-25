using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject WinUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] FloatVariable health;
    
    [SerializeField] GameObject respawn;
    [Header("Events")]
    //[SerializeField] IntEvent scoreEvent;
    [SerializeField] voidEvent gameStartEvent;
    [SerializeField] GameObjectEvent respawnEvent;
   public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER,
        GAME_WON
    }
    public State state = State.TITLE;
    public float timer = 0;
   

    private void OnEnable()
    {
        //scoreEvent.Subscribe(onAddPoints);
    }
    private void OnDisable()
    {
        //scoreEvent.Unsubscribe(onAddPoints);
    }
    void Start()
    {
        
    }

    public float Timer
    {
        get { return timer; }
        set { timer = value; timerUI.text = "Timer:" + string.Format("{0:F1}",timer); }
    }

    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                titleUI.SetActive(true);
                GameOverUI.SetActive(false);
                WinUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                break;

            case State.START_GAME:
                titleUI.SetActive(false);
                GameOverUI.SetActive(false);
                WinUI.SetActive(false);
                Time.timeScale = 1;
                timer = 60;
                health.value = 100;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameStartEvent.RaiseEvent();                
                respawnEvent.RaiseEvent(respawn);
                state = State.PLAY_GAME;
                break;

            case State.PLAY_GAME:
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {

                    state = State.GAME_OVER;
                }
                break;

            case State.GAME_OVER:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                GameOverUI.SetActive(true);
                break; 
            case State.GAME_WON:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                WinUI.SetActive(true);
                break;
        }
        healthUI.value = health.value / 100.0f;


    }
    public void onStartGame()
    {
        state = State.START_GAME;
    }
    public void OnExitGame()
    {
        state = State.TITLE;
    }
    public void onPlayerDead()
    {
        state = State.GAME_OVER;
    }
    public void onPlayerWin()
    {
        state = State.GAME_WON;
    }
    public void onAddPoints(int points)
    {
        print(points);
    }
    public void onAddTime(int time)
    {
        Timer += time;
    }

}
