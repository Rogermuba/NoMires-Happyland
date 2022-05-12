    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PoisonousWater : MonoBehaviour
{
    [SerializeField]
    public AudioClip _lessHealthSound;
    public AudioSource audio1;

    [SerializeField]
    private float healthQTY = 5.0f;

    public void Start() {
        audio1 = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FirstPersonController player = other.GetComponent<FirstPersonController>(); 
            player.RemoveHealth(healthQTY);
            //AudioSource.PlayOneSHot(_lessHealthSound, transform.position, 1f)
            audio1.PlayOneShot(_lessHealthSound, 0.5f);
        }
    }   
}