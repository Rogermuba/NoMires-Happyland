using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hongo : MonoBehaviour
{

    public Player playerscript;
    public bool timerIsRunning = true;
    public float timeRemaining=100;
    public int lifeplayer;
    // Start is called before the first frame update
    void Start()
    {
        lifeplayer = (int)playerscript.playerLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag( "Player"))
        {
            if (timerIsRunning)
            {
                if (timeRemaining > 20)
                {
                    timeRemaining -= Time.deltaTime;
                    playerscript.RemoveHealth(lifeplayer);
                    if (lifeplayer <= 10) {
                        timerIsRunning = false;
                    }
                }
                else
                {
                    timeRemaining = 100;
                    timerIsRunning = false;
                }
            }
            
        }
    }
    private void OnCollisionExit(Collision collision) {
        timeRemaining = 100;
        timerIsRunning = true;
    }

}
