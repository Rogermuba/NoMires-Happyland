using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool gameOver = false;

    public void Awake()
    {
         Instance= this;
    }

    public void GameOver()
    {
          gameOver = true;  
    }


}
