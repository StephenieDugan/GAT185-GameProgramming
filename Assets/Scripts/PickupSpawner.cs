using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] Transform pickupList;
    [SerializeField] voidEvent gameStartEvent = default;
    List<Pickup> pickups;
    public void Start()
    {
        foreach(Transform pickup in pickupList)
        {
            if(pickup.TryGetComponent<Pickup>(out Pickup pickupstuff))
            {
                pickups.Add(pickupstuff);
            }
        }
    }

    public void OnEnable()
    {
        gameStartEvent.Subscribe(onStartGame);
    }

    private void onStartGame()
    {
        foreach(Pickup item in pickups)
        {
            item.gameObject.SetActive(true);
            item.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
