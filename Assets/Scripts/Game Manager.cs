using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
   public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
    }
    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 0;

    void Start()
    {

    }

    public int Lives
    {
        get { return lives; }
        set { lives = value; livesUI.text = $"lives: {lives}"; }

    }
    public float Timer
    {
        get { return timer; }
        set { timer = value; timerUI.text = string.Format("{0:F1}",timer); }
    }

    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                Time.timeScale = 1;
                timer = 60;
                lives = 3;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
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

                break;
        }
    }
    public void onStartGame()
    {
        state = State.START_GAME;
    }


}
