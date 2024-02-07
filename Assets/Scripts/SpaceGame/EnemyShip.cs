using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShip : Enemy
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private float minFireRte;
    [SerializeField] private float maxFireRte;

    private void Start()
    {
        weapon.Equip();
        StartCoroutine(FireTimerCR());
    }

    IEnumerator FireTimerCR()
    {
        while (true)
        {
            float time = Random.Range(minFireRte, maxFireRte);
            yield return new WaitForSeconds(time);
            weapon.Use();
        }
    }

}
