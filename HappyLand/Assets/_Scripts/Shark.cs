using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public void OnTriggerStay(Collider collision)
    {
      if(collision.tag =="Player")
      { 
         Debug.Log("Ingresa Player");
         if(Input.GetKeyDown(KeyCode.K))
           {

             Debug.Log("Player presiona E");
             
             Player player = collision.GetComponent<Player>();
             if (player != null && player.hasCoin==true)
             {
                    IU_Manager iu_Manager = GameObject.Find("Canvas").GetComponent<IU_Manager>();
                    if(iu_Manager != null)
                    {
                        iu_Manager.PaywithCoin();
                    }
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                player.EnableWeapons();
             }
             else 
                 {
                      Debug.Log("Get out of here");
                 }
         }

      }
        
    }



    }
