using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoePickup : MonoBehaviour
{
    public GameObject player;
    public GameObject pickupEffect;
    public int soundToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            player.GetComponent<PlayerController>().IncreaseMaxSpeed();
            Instantiate(pickupEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(soundToPlay);
        }
    }
}
