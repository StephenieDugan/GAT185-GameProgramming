using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int score = 0;
    private float health = 100;
    public int Score { get { return score; } set { score = value; } }

    public void AddPoints(int points)
    {
        score += points;
    }

}
