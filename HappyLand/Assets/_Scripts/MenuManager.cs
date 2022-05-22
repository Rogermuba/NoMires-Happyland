using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   
    public void BotonInicio()
    {
        SceneManager.LoadScene("Forest_Scene 1");
    }

    public void BotonConfiguracion()
    {
        SceneManager.LoadScene("Opciones");
    }   



}
