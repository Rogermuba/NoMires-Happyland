using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1.0F;
    
    // Update is called once per frame
    void Update()
    {
      float _mousex =  Input.GetAxis("Mouse X");
      //Se obtiene el valor del angulo Euler actual y luego le asignamos un nuevo valor.
      
      //Funcion sin usar variables temporales
      //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (_mousex * _sensitivity), transform.localEulerAngles.z);
      
      //Usando variables temporales  
      Vector3 newRotation = transform.localEulerAngles;
      newRotation.y += _mousex * _sensitivity;
      transform.localEulerAngles = newRotation;
           
      
    }
}
