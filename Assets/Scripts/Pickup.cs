using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;
    [SerializeField] voidEvent TimeBuffEvent;


    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            if(tag == "Coin1")
            {
                player.AddPoints(10);
            }
            else if(tag == "Coin2")
            {
                player.AddPoints(30);
            }
            else if(tag == "TimeBuff")
            {
                TimeBuffEvent.RaiseEvent();
            }
        }

        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
