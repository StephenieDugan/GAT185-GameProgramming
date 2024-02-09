using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private PathFollower pathFollower;
    //events
    [SerializeField] private IntEvent scoreEvent;
    [SerializeField] private IntVariable score;
    [SerializeField] private FloatVariable health;
    //prefabs
    [SerializeField] private GameObject hitPrefab;
    [SerializeField] private GameObject destroyPrefab;
    private void Start()
    {
        
        scoreEvent.Subscribe(AddPoints);
        health.value = 100;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inventory.Use();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            inventory.onStopUse();
        }
        pathFollower.speed = (Input.GetKey(KeyCode.Escape)) ? 2 : 1;
       
    }
   

    public void AddPoints(int points)
    {
        score.value += points;
        Debug.Log(score.value);
    }
    
    public void ApplyHealth(float health)
    {
        this.health.value += health;
        this.health.value = Mathf.Min(health, 100);
    }

    public void ApplyDamage(float damage)
    {
        health.value -= damage;
        if (health.value <= 0)
        {
           if (destroyPrefab != null)
            {
                Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);

        }
        else
        {
            if (hitPrefab != null)
            {
                Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}