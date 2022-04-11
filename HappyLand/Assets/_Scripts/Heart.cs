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
    public FirstPersonController fpc;


    public void OnTriggerEnter(Collider other)
    {
        {
            if (other.tag == "Player")
            {

                Debug.Log("Entra el player");
                Player playerGame = other.GetComponent<Player>();
                playerGame.AddHeatl(healtQTY);
                AudioSource.PlayClipAtPoint(_heartSound, transform.position, 1f);

                //Destroy(this.gameObject);
            }
        }



    }

}