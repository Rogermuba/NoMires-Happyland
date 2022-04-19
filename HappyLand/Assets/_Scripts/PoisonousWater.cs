using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonousWater : MonoBehaviour
{
    [SerializeField]
    private AudioClip _lessHealthSound;

    [SerializeField]
    private float healthQTY = 5.0f;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.RemoveHealth(healthQTY);
            AudioSource.PlayClipAtPoint(_lessHealthSound, transform.position, 1f);
        }
    }   
}