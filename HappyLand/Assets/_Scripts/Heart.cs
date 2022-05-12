using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Heart : MonoBehaviour
{
    [SerializeField]
    private AudioClip _heartSound;
    [SerializeField]
    private float healtQTY = 5.0f;
    


    public void OnTriggerEnter(Collider other)
    {
        {
            if (other.tag == "Player")
            {

                Debug.Log("Entra el player");
                FirstPersonController player = other.GetComponent<FirstPersonController>();
                player.AddHeatl(healtQTY);
                AudioSource.PlayClipAtPoint(_heartSound, transform.position, 1f);

                Destroy(this.gameObject);
            }
        }



    }

}