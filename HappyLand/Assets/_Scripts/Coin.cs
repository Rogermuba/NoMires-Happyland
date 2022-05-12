using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip _coinPickUpSound;
    

  

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        { 
          if(Input.GetKeyDown(KeyCode.E))
          {
                FirstPersonController player = other.GetComponent<FirstPersonController>();
                if(player != null)
                {
                   Debug.Log("recoge moneda");
                   player.hasCoin=true; 
                   AudioSource.PlayClipAtPoint(_coinPickUpSound, transform.position, 1f);
                    Destroy(this.gameObject);

                }
          }
        }
    }

}
