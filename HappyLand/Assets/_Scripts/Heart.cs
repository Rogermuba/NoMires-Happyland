using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]
    private AudioClip _heartSound;
    [SerializeField]
    private float healtQTY = 5.0f;
    
    public void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "player")
        {
            Player player = other.GetComponent<Player>();
            player.AddHeatl(healtQTY);
            AudioSource.PlayClipAtPoint(_heartSound, transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
    
    
}
