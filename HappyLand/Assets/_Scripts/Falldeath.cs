using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
public class Falldeath : MonoBehaviour
{
    [SerializeField]
    private AudioClip _lessHealthSound;

    [SerializeField]
    private float healthQTY = 5.0f;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            FirstPersonController player = other.GetComponent<FirstPersonController>();
            player.RemoveHealth(healthQTY);
            AudioSource.PlayClipAtPoint(_lessHealthSound, transform.position, 1f);
            SceneManager.LoadScene(1);
        }
    }
}