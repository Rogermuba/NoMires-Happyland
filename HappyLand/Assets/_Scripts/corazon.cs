using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corazon : MonoBehaviour
{
    [SerializeField]
    private AudioClip _corazonPickUpSound;
    [SerializeField]
    private float _pickupHealt = 5.0f;


    //public void OnTriggerStay(Collider other)
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.playerLife = _pickupHealt;
                    AudioSource.PlayClipAtPoint(_corazonPickUpSound, transform.position, 1f);
                    Destroy(this.gameObject);

                }
            //}
        }
    }

}
